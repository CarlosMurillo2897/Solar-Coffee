using System.Collections.Generic;

namespace SolarCoffee.Services.Customer
{
    public interface ICustomerService
    {
        List<Data.Models.Customer> GetAllCustomers();
        Data.Models.Customer GetCustomerById(int id);
        ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer);
        ServiceResponse<bool> DeleteCustomer(int id);
    }
}
