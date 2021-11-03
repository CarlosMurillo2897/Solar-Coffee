using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Customer;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(
            ILogger<CustomerController> logger,
            ICustomerService customerService
            )
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpPost("/api/v1/customer")]
        public ActionResult CreateCustomer([FromBody] CustomerModel customer)
        {
            var now = DateTime.UtcNow;
            
            _logger.LogInformation("Creating a new Customer.");
            customer.CreatedOn = now;
            customer.UpdatedOn = now;
            
            customer.PrimaryAddress.CreatedOn = now;
            customer.PrimaryAddress.UpdatedOn = now;

            var customerData = CustomerMapper.SerializeCustomer(customer);
            var newCustomer = _customerService.CreateCustomer(customerData);
            
            return Ok(newCustomer);
        }

        [HttpGet("/api/v1/customer")]
        public ActionResult GetCustomers()
        {
            _logger.LogInformation("Getting Customers.");

            var customers = _customerService.GetAllCustomers();
            var customerModels = customers
                .Select(CustomerMapper.SerializeCustomer)
                .OrderByDescending(customer => customer.CreatedOn)
                .ToList();
            
            return Ok(customerModels);
        }

        [HttpDelete("/api/v1/customer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation("Deleting a Customer.");
            var response = _customerService.DeleteCustomer(id);
            return Ok(response);
        }

    }
}
