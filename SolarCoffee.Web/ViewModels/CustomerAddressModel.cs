using System;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// Customer Address Entity DTO.
    /// </summary>
    public class CustomerAddressModel : BaseViewModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
