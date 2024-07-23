using Microsoft.AspNetCore.Mvc;
using GTI.Dashboard.Services.Employees;
using Serilog;

namespace GTI.Dashboard.WebApi.Controllers
{

    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .CreateLogger();

                Log.Information("GET request received for GetEmployees endpoint.");

                Log.Information("GET request processed successfully for GetEmployees endpoint.");

                return Ok(await _employeeService.GetEmployees());

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing GET request for GetEmployees endpoint.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound("Funcionário não encontrado no sistema.");

            return Ok(employee);
        }
    }
}
