using SolarCoffee.Data.Models;
using System.Collections.Generic;

namespace SolarCoffee.Services.Inventory
{
    public interface IInventoryService
    {
        public List<ProductInventory> GetCurrentInventory();
        public ProductInventory GetProductById(int id);
        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment);
        public void CreateSnapshot();
        public List<ProductInventorySnapshot> GetSnapshotHistory();
    }
}
