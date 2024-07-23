using GTI.Dashboard.Services.GPTW;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GTI.Dashboard.WebApi.Controllers
{
    [Route("api/gptw")]
    [ApiController]
    public class GPTWController : ControllerBase
    {
        private readonly IGPTWService _GPTWService;

        public GPTWController(IGPTWService gptwService)
        {
            _GPTWService = gptwService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGPTW()
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .CreateLogger();

                Log.Information("GET request received for GetGPTW endpoint.");

                Log.Information("GET request processed successfully for GetGPTW endpoint.");

                return Ok(await _GPTWService.GetGPTW());

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing GET request for GetGPTW endpoint.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [Route("/engajamento")]
        [HttpGet]
        public async Task<IActionResult> GetEngagement()
        {
            return Ok(await _GPTWService.GetEngagement());
        }

        [Route("/questions")]
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            return Ok(await _GPTWService.GetQuestions());
        }
    }
}
