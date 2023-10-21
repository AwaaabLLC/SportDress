using IDataAccessLayer;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class EmployeesAccessor : IEmployeeAccessor
    {
        public bool verifyEmployee(string username, string password)
        {
            bool result = false;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("");
            return result;
        }
    }
}
