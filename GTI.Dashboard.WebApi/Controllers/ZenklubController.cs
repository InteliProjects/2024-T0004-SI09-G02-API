using Microsoft.AspNetCore.Mvc;
using GTI.Dashboard.Services.Zenklub;
using Serilog;

namespace GTI.Dashboard.WebApi.Controllers
{

    [Route("api/zenklub")]
    [ApiController]
    public class ZenklubController : ControllerBase
    {
        private readonly IZenklubService _zenklubService;

        public ZenklubController(IZenklubService zenklubService)
        {
            _zenklubService = zenklubService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .CreateLogger();

                Log.Information("GET request received for GetDepartment endpoint.");

                Log.Information("GET request processed successfully for GetDepartment endpoint.");

                return Ok(await _zenklubService.GetDepartment());

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing GET request for GetDepartment endpoint.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [Route("/dep")]
        [HttpGet]
        public async Task<IActionResult> GetTotalSessionsByDepartment()
        {
            var session_department = await _zenklubService.GetTotalSessionsByDepartment();
            if (session_department == null)
                return NotFound(session_department);

            return Ok(session_department);
        }
    }
}
