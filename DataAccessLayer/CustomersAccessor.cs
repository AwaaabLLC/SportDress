using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using DataObjects;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class CustomersAccessor : ICustomerAccessor
    {
        public CustomersAccessor() { }

        public List<Customer> SelectAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_all_customers", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerID = reader.GetInt32(0);
                        customer.GivenName = reader.GetString(1);
                        customer.FamilyName = reader.GetString (2);
                        customer.PhoneNumber = reader.GetString (3);
                        customer.Email = reader.GetString(4);
                        customer.line1 = reader.GetString (5);
                        customer.line2 = reader.GetString(6);
                        customer.zipcode = reader.GetString(7);
                        customers.Add(customer);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return customers;
        }
    }
}
