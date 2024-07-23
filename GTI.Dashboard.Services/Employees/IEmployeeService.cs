using GTI.Dashboard.Repository;

namespace GTI.Dashboard.Services.Employees
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> GetEmployeeById(int id);
        Task<IEnumerable<EmployeeModel>> GetEmployees();
        Task<int> InsertEmployee(EmployeeModel employeeModel);
        Task<int> DeleteEmployee(int id);
    }
}
