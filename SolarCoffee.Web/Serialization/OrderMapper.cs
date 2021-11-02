using System;
using System.Collections.Generic;
using System.Linq;
using SolarCoffee.Data.Models;
using SolarCoffee.Web.ViewModels;

namespace SolarCoffee.Web.Serialization
{
    /// <summary>
    /// Handles Mapping Order Data Models to and from Related View Models.
    /// </summary>
    public static class OrderMapper
    {
        /// <summary>
        /// Maps an InvoiceModel (View Model) into a SalesOrder (Data).
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public static SalesOrder SerializeInvoiceToOrder(InvoiceModel invoice)
        {
            var salesOrderItems = invoice.LineItems
                .Select(item => new SalesOrderItem
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializeProductModel(item.Product)
                }).ToList();
            return new SalesOrder
            {
                SalesOrderItems = salesOrderItems,
                CreatedOn =  DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Maps a Collection of SalesOrders (Data) into OrderModels (View Models).
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public static List<OrderModel> SerializeOrdersToViewModels(IEnumerable<SalesOrder> orders)
        {
            return orders.Select(order =>
                new OrderModel
                {
                    Id = order.Id,
                    CreatedOn = order.CreatedOn,
                    UpdatedOn = order.UpdatedOn,
                    SalesOrderItems = SerializeSalesOrderItems(order.SalesOrderItems),
                    Customer = CustomerMapper.SerializeCustomer(order.Customer),
                    IsPaid = order.IsPaid
                }).ToList();
        }

        /// <summary>
        /// Maps a Collection of SalesOrderItems (Data) into SalesOrderItemModels (View Models).
        /// </summary>
        /// <param name="orderItems"></param>
        /// <returns></returns>
        private static List<SalesOrderItemModel> SerializeSalesOrderItems(IEnumerable<SalesOrderItem> orderItems)
        {
            return orderItems
                .Select(item => new SalesOrderItemModel
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializeProductModel(item.Product)
                }).ToList();
        }
    }
}
