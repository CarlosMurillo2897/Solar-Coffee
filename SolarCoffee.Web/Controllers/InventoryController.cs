using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolarCoffee.Services.Inventory;
using SolarCoffee.Web.Serialization;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Controllers
{
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(
            ILogger<InventoryController> logger,
            IInventoryService inventoryService
            )
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet("/api/v1/inventory")]
        public ActionResult GetInventory()
        {
            _logger.LogInformation("Getting All Inventory.");

            var inventory = _inventoryService.GetCurrentInventory()
                .Select(ProductInventoryMapper.SerializeProductInventory)
                .OrderBy(inv => inv.Product.Name)
                .ToList();
            return Ok(inventory);
        }

        [HttpPatch("/api/v1/inventory")]
        public ActionResult UpdateInventory([FromBody] ShipmentModel shipment)
        {
            var id = shipment.ProductId;
            var adjustment = shipment.Adjustment;

            _logger.LogInformation($"Updating Inventory for {id} - Adjustment: {adjustment}");

            var inventory = _inventoryService.UpdateUnitsAvailable(
                id, 
                adjustment
                );
            return Ok(inventory);
        }

    }
}
