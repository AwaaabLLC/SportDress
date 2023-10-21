using DataAccessLayer;
using ILogicLayer;
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
            result = employeesAccessor.verifyEmployee(username, password);
            return result;
        }
    }
}
