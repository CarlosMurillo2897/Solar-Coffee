using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialization
{
    /// <summary>
    /// Handles Mapping Customer Data Models to and from Related View Models.
    /// </summary>
    public class CustomerMapper
    {
        /// <summary>
        /// Serializes a Customer (Data) into a CustomerModel (View Model).
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerModel SerializeCustomer(Customer customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = CustomerAddressMapper.SerializeCustomerAddress(customer.PrimaryAddress)
            };
        }

        /// <summary>
        /// Serializes a CustomerModel (View Model) into a Customer (Data).
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer SerializeCustomer(CustomerModel customer)
        {
            return new Customer
            {
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = CustomerAddressMapper.SerializeCustomerAddress(customer.PrimaryAddress)
            };
        }
    }
}
