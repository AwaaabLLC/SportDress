using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
{
    public interface IEmployeeAccessor
    {
        public int verifyEmployee(string username, string password);
        public List<string> selectEmployeeRoles(int employeeId);
    }
}
