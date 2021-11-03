using System;
using System.ComponentModel.DataAnnotations;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// Customer Entity DTO.
    /// </summary>
    public class CustomerModel : BaseViewModel
    {
        [MaxLength(32)] public string FirstName { get; set; }
        [MaxLength(32)] public string LastName { get; set; }
        public CustomerAddressModel PrimaryAddress { get; set; }
    }
}
