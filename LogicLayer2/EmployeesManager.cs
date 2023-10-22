using DataAccessLayer;
using ILogicLayer;
using System.Security.Cryptography;
using System.Text;
namespace LogicLayer
{
    public class EmployeesManager : ILogicLayer.IEmployeesManager
    {
        private EmployeesAccessor employeesAccessor;

        public EmployeesManager()
        {
            employeesAccessor = new EmployeesAccessor();
        }

        public bool verifyEmployee(string username, string password)
        {
            bool result = false;
            result = employeesAccessor.verifyEmployee(username, hashSHA256(password));
            return result;
        }
        private string hashSHA256(string source)
        {
            string result = "";
            byte[] data;
            using (SHA256 sha256sha = SHA256.Create())
            {
                data = sha256sha.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            var s = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            result = s.ToString();
            return result;
        }
    }
}

