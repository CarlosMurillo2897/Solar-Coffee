namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// Sales Order Items Entity DTO.
    /// </summary>
    public class SalesOrderItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductModel Product { get; set; }

    }
}
