using GTI.Dashboard.Services.CID;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GTI.Dashboard.WebApi.Controllers
{
    [Route("api/cid")]
    [ApiController]
    public class CIDController : ControllerBase
    {
        private readonly ICIDService _CIDService;

        public CIDController(ICIDService cidService)
        {
            _CIDService = cidService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCID()
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .CreateLogger();

                Log.Information("GET request received for GetCID endpoint.");

                Log.Information("GET request processed successfully for GetCID endpoint.");

                return Ok(await _CIDService.GetCID());

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing GET request for GetCID endpoint.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet("{unidade}")]
        public async Task<IActionResult> GetCauseByHealthUnit(string unidade)
        {
            return Ok(await _CIDService.GetCauseByHealthUnit(unidade));
        }

        [Route("/certificate_quantity")]
        [HttpGet]
        public async Task<IActionResult> GetDoctorCertificateQuantity()
        {
            return Ok(await _CIDService.GetDoctorCertificateQuantity());
        }
    }
}
