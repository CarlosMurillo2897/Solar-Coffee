using System;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// Base View Model with common properties.
    /// </summary>
    public class BaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
