﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolarCoffee.Data;

namespace SolarCoffee.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly SolarDbContext _db;

        public CustomerService(SolarDbContext dbContext)
        {
            _db = dbContext;
        }
        /// <summary>
        /// Returns a Customers list from DB.
        /// </summary>
        /// <returns>List<Customer></returns>
        public List<Data.Models.Customer> GetAllCustomers()
        {
            return _db.Customers
                .Include(customer => customer.PrimaryAddress)
                .OrderBy(customer => customer.LastName)
                .ToList();
        }

        /// <summary>
        /// Get a customer record by primary key.
        /// </summary>
        /// <param name="id">int customer primary key</param>
        /// <returns>Customer</returns>
        public Data.Models.Customer GetCustomerById(int id)
        {
            return _db.Customers.Find(id);
        }

        /// <summary>
        /// Adds a new Customer record.
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <returns>ServiceResponse<Customer></returns>
        public ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer)
        {
            try
            {
                _db.Add(customer);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Customer>
                {
                    IsSuccess = true,
                    Message = "New Customer added.",
                    Time = DateTime.UtcNow,
                    Data = customer
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Customer>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = customer
                };
            }
        }
        /// <summary>
        /// Delete a Customer record.
        /// </summary>
        /// <param name="id">int customer primary key</param>
        /// <returns>ServiceResponse<bool></returns>
        public ServiceResponse<bool> DeleteCustomer(int id)
        {
            var customer = _db.Customers.Find(id);
            var now = DateTime.UtcNow;
            
            if (customer == null)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Message = "Customer to delete not found.",
                    Time = now,
                    Data = false
                };
            }

            try
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
                
                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Message = "Customer removed.",
                    Time = now,
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = now,
                    Data = false
                };
            }
        }
    }
}
