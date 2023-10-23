using IDataAccessLayer;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class EmployeesAccessor : IEmployeeAccessor
    {
        public List<string> selectEmployeeRoles(int employeeId)
        {
            List<string> employeeRoles = new List<string>();
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_select_roles_by_employee_id", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employee_id", employeeId);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        employeeRoles.Add(reader.GetString(0));
                    }                     
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { conn.Close(); }
            return employeeRoles;
        }

        public int verifyEmployee(string username, string password)
        {
            int result = 0;
            SqlConnection conn = DBConnection.getConnection();
            var cmd = new SqlCommand("sp_verify_user",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", username);
            cmd.Parameters.AddWithValue("@PasswordHash", password);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    reader.Read();
                    result = reader.GetInt32(0);
                }
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
