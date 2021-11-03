using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SolarCoffee.Data;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly SolarDbContext _db;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(SolarDbContext dbContext, ILogger<InventoryService> logger)
        {
            _db = dbContext;
            _logger = logger;
        }
        
        /// <summary>
        /// Returns all current Inventory from DB.
        /// </summary>
        /// <returns>List<ProductInventory></returns>
        public List<ProductInventory> GetCurrentInventory()
        {
            return _db.ProductInventories
                .Include(pi => pi.Product)
                .Where(pi => !pi.Product.IsArchived)
                .ToList();
        }

        /// <summary>
        /// Gets a Product Inventory instance by Product ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProductInventory</returns>
        public ProductInventory GetByProductId(int id)
        {
            return _db.ProductInventories
                .Include(pi => pi.Product)
                .FirstOrDefault(pi => pi.Product.Id == id);
        }

        /// <summary>
        /// Updates number of units available of the provided Product id.
        /// Adjusts QuantityOnHand by adjustment value.
        /// </summary>
        /// <param name="id">productId</param>
        /// <param name="adjustment">number of units added / removed from inventory.</param>
        /// <returns></returns>
        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment)
        {
            try
            {
                var inventory = _db.ProductInventories
                    .Include(inv => inv.Product)
                    .First(inv => inv.Product.Id == id);

                inventory.QuantityOnHand += adjustment;

                try
                {
                    CreateSnapshot(inventory);
                }
                catch (Exception e)
                {
                    _logger.LogError("Error creating Inventory Snapshot.");
                    _logger.LogError(e.StackTrace);
                }

                _db.SaveChanges();

                return new ServiceResponse<ProductInventory>
                {
                    IsSuccess = true,
                    Message = $"Product {id} inventory adjusted.",
                    Time = DateTime.UtcNow,
                    Data = inventory
                };
            }
            catch (Exception)
            {
                return new ServiceResponse<ProductInventory>
                {
                    IsSuccess = false,
                    Message = $"Error updating Product Inventory Quantity on hand.",
                    Time = DateTime.UtcNow,
                    Data = null
                };
            }
        }

        /// <summary>
        /// Create Snapshot according current Product Inventory.
        /// </summary>
        private void CreateSnapshot(ProductInventory inventory)
        {
            var now = DateTime.UtcNow;
            var snapshot = new ProductInventorySnapshot
            {
                SnapshotTime = now,
                Product = inventory.Product,
                QuantityOnHand = inventory.QuantityOnHand
            };
            
            _db.Add(snapshot);
        }

        /// <summary>
        /// Return Snapshot History for the previous 6 hours.
        /// </summary>
        /// <returns>List<ProductInventorySnapshot></returns>
        public List<ProductInventorySnapshot> GetSnapshotHistory()
        {
            var earliest = DateTime.UtcNow - TimeSpan.FromHours(6);
            return _db.ProductInventorySnapshots
                .Include(snap => snap.Product)
                .Where(snap =>
                    snap.SnapshotTime > earliest && !snap.Product.IsArchived
                ).ToList();
        }
    }
}
