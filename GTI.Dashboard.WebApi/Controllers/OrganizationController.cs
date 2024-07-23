using GTI.Dashboard.Services.Organization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GTI.Dashboard.WebApi.Controllers
{
    [Route("api/organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _OrganizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _OrganizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizations()
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .CreateLogger();

                Log.Information("GET request received for GetOrganizations endpoint.");

                Log.Information("GET request processed successfully for GetOrganizations endpoint.");

                return Ok(await _OrganizationService.GetOrganizations());

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing GET request for GetOrganizations endpoint.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        [Route("/notas_unidades")]
        [HttpGet]
        public async Task<IActionResult> GetOrganizationsUnits()
        {
            return Ok(await _OrganizationService.GetOrganizationsUnits());
        }
    }
}
