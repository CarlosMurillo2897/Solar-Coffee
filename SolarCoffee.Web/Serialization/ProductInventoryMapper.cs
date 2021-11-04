using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialization
{
    /// <summary>
    /// Handles Mapping Product Inventory Models to and from Related View Models.
    /// </summary>
    public static class ProductInventoryMapper
    {
        /// <summary>
        /// Maps a ProductInventory (Data) into a ProductInventoryModel (View Model).
        /// </summary>
        /// <param name="productInventory"></param>
        /// <returns></returns>
        public static ProductInventoryModel SerializeProductInventory(ProductInventory productInventory)
        {
            return new ProductInventoryModel
            {
                Id = productInventory.Id,
                Product = ProductMapper.SerializeProductModel(productInventory.Product),
                IdealQuantity = productInventory.IdealQuantity,
                QuantityOnHand = productInventory.QuantityOnHand
            };
        }

    }
}
