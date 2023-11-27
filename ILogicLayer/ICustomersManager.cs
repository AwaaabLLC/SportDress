using System;
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
        public int addZipCode(Zipcode zipcode);
        public List<Customer> getAllCustomers();
        public List<Zipcode> getZipcodes();
    }
}
