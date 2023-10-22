using IDataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class EmployeesAccessor : IEmployeeAccessor
    {
        public bool verifyEmployee(string username, string password)
        {
            bool result = false;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_verify_user",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", username);
            cmd.Parameters.AddWithValue("@PasswordHash", password);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {result = true; }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return result;
        }
    }
}
