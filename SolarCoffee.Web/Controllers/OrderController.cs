using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Customer;
using SolarCoffee.Services.Order;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(
            ILogger<OrderController> logger,
            IOrderService orderService,
            ICustomerService customerService
            )
        {
            _logger = logger;
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpPost("/api/v1/invoice")]
        public ActionResult GenerateNewOrder([FromBody] InvoiceModel invoice)
        {
            _logger.LogInformation("Generating Invoice.");
            var order = OrderMapper.SerializeInvoiceToOrder(invoice);
            order.Customer = _customerService.GetCustomerById(invoice.CustomerId);
            _orderService.GenerateOpenOrder(order);
            return Ok();
        }

        [HttpGet("/api/v1/order")]
        public ActionResult GetOrders()
        {
            _logger.LogInformation("Getting all Orders.");
            var orders = _orderService.GetOrders();
            var orderModels = OrderMapper.SerializeOrdersToViewModels(orders);
            return Ok(orderModels);
        }

        [HttpPatch("/api/v1/order/complete/{id}")]
        public ActionResult MarkOrderComplete(int id)
        {
            _logger.LogInformation($"Marking Order {id} as complete.");
            _orderService.MarkFulfilled(id);
            return Ok();
        }

    }
}
