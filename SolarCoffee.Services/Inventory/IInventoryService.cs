using SolarCoffee.Data.Models;
using System.Collections.Generic;

namespace SolarCoffee.Services.Inventory
{
    public interface IInventoryService
    {
        public List<ProductInventory> GetCurrentInventory();
        public ProductInventory GetByProductId(int id);
        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment);
        public List<ProductInventorySnapshot> GetSnapshotHistory();
    }
}
