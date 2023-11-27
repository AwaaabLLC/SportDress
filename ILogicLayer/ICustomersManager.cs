﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace ILogicLayer
{
    public interface ICustomersManager
    {
        public int add(Customer customer);
        public List<Customer> getAllCustomers();
    }
}
