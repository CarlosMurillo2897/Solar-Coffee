using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarCoffee.Data.Models;

namespace SolarCoffee.Services.Order
{
    public class OrderService : IOrderService
    {
        public List<SalesOrder> GetOrders()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> GenerateInvoiceForOrder(SalesOrder order)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> MarkFulfilled(int id)
        {
            throw new NotImplementedException();
        }
    }
}
