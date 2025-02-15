using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

// TODO: AutoMapper can be used with Serialization entities.
namespace SolarCoffee.Web.Serialization
{
    /// <summary>
    /// Handles Mapping Customer Address Models to and from Related View Models.
    /// </summary>
    public static class CustomerAddressMapper
    {
        /// <summary>
        /// Maps a Customer Address (Data) into a CustomerAddressModel (View Model).
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddressModel SerializeCustomerAddress(CustomerAddress address)
        {
            return new CustomerAddressModel
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                Country = address.Country,
                PostalCode = address.PostalCode,
                CreatedOn = address.CreatedOn,
                UpdatedOn = address.UpdatedOn
            };
        }

        /// <summary>
        /// Maps a CustomerAddressModel (View Model) into a Customer Address (Data).
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddress SerializeCustomerAddress(CustomerAddressModel address)
        {
            return new CustomerAddress
            {
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                Country = address.Country,
                PostalCode = address.PostalCode,
                CreatedOn = address.CreatedOn,
                UpdatedOn = address.UpdatedOn
            };
        }

    }
}
