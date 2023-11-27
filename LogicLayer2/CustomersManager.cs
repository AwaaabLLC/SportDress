﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogicLayer;
using IDataAccessLayer;
using DataAccessLayer;
using DataObjects;

namespace LogicLayer
{
    public class CustomersManager : ICustomersManager
    {
        private ICustomerAccessor _customerAccessor;
        public CustomersManager() { 
            _customerAccessor = new CustomersAccessor();
        }

        public int add(Customer customer)
        {
            int result = 0;
            result = _customerAccessor.insert(customer);
            return result;
        }

        public int addZipCode(Zipcode zipcode)
        {
            int result = 0;
            result = _customerAccessor.insertZipcode(zipcode);
            return result;
        }

        public List<Customer> getAllCustomers()
        {
            List<Customer> list = new List<Customer>();
            list = _customerAccessor.SelectAllCustomers();
            return list;
        }

        public List<Zipcode> getZipcodes()
        {
            List<Zipcode> codes = new List<Zipcode>();
            codes = _customerAccessor.SelectZipcodes();
            return codes;
        }
    }
}
