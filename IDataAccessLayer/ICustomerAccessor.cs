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
        public int insert(Customer customer);
        public int insertCustomerCreditCard(CustomerCreditCard creditCard);
        public int insertZipcode(Zipcode zipcode);
        public List<Customer> SelectAllCustomers();
        public List<Zipcode> SelectZipcodes();
    }
}
