using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogicLayer
{
    public interface IEmployeesManager
    {
        public int verifyEmployee(string username, string password);
        public List<string> getEmployeeRoles(int isEmployeeVerify);
    }
}
