using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace IDataAccessLayer
{
    public interface ICustomerAccessor
    {
        public List<Customer> SelectAllCustomers();
    }
}
