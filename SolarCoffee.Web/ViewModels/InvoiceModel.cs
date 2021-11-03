using System;
using System.Collections.Generic;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// Open SalesOrders Entity DTO.
    /// </summary>
    public class InvoiceModel : BaseViewModel
    {
        public int CustomerId { get; set; }
        public List<SalesOrderItemModel> LineItems { get; set; }
    }
}
