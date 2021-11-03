using System;
using System.Collections.Generic;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// Order Entity DTO.
    /// </summary>
    public class OrderModel : BaseViewModel
    {
        public CustomerModel Customer{ get; set; }
        public List<SalesOrderItemModel> SalesOrderItems { get; set; }
        public bool IsPaid { get; set; }
    }
}
