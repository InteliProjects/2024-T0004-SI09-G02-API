using GTI.Dashboard.Repository;

namespace GTI.Dashboard.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<EmployeeModel> GetEmployeeById(int id) => _employeeRepository.GetEmployeeById(id);

        public Task<IEnumerable<EmployeeModel>> GetEmployees() => _employeeRepository.GetEmployees();

        public Task<int> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertEmployee(EmployeeModel employeeModel)
        {
            throw new NotImplementedException();
        }
    }
}
