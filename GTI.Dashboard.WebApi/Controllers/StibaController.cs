using GTI.Dashboard.Services.Stiba;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;

namespace GTI.Dashboard.WebApi.Controllers
{
    [Route("api/stiba")]
    [ApiController]
    public class StibaController : ControllerBase
    {
        private readonly IStibaService _stibaservice;

        public StibaController(IStibaService stibaservice)
        {
            _stibaservice = stibaservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetStibas()
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information() 
                    .WriteTo.Console() 
                    .CreateLogger();

                Log.Information("GET request received for GetStibas endpoint.");

                var stibas = await _stibaservice.GetStibas();

                Log.Information("GET request processed successfully for GetStibas endpoint.");

                return Ok(stibas);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing GET request for GetStibas endpoint.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
