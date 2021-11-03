using System;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// Product Entity DTO
    /// </summary>
    public class ProductModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsArchived { get; set; }
    }
}
