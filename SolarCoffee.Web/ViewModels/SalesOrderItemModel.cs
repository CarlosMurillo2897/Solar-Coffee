namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// View Model for Sales Order Items.
    /// </summary>
    public class SalesOrderItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductModel Product { get; set; }

    }
}
