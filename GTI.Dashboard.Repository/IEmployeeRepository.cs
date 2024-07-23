using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeeById(int id);
        Task<int> InsertEmployee(EmployeeModel employeeModel);
        Task<int> DeleteEmployee(int id);
        Task<int> UpdateEmployee(EmployeeModel employeeModel);
    }
}
