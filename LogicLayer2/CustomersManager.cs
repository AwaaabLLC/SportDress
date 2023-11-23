using System;
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

        public List<Customer> getAllCustomers()
        {
            List<Customer> list = new List<Customer>();
            list = _customerAccessor.SelectAllCustomers();
            return list;
        }
    }
}
