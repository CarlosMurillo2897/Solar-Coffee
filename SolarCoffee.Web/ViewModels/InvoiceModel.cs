using System;
using System.Collections.Generic;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// Open SalesOrders Entity DTO.
    /// </summary>
    public class InvoiceModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CustomerId { get; set; }
        public List<SalesOrderItemModel> LineItems { get; set; }
    }
}
