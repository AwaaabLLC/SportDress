using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogicLayer
{
    public interface IEmployeesManager
    {
        public bool verifyEmployee(string username, string password);
    }
}
