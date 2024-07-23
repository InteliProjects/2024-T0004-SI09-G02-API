using System;
using System.Threading.Tasks;
using GTI.Dashboard.Repository;
using GTI.Dashboard.Services;
using GTI.Dashboard.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GTI.Dashboard.WebApi.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logsBusiness;

        public LogsController(ILogService logsBusiness)
        {
            _logsBusiness = logsBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> LogEntry([FromBody] LogModel logModel)
        {
            try
            {
                Log.Information("POST request received for LogEntry endpoint.");

                await _logsBusiness.LogEntry(logModel);

                Log.Information("POST request processed successfully for LogEntry endpoint.");

                return Ok("Log entry inserted successfully.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing POST request for LogEntry endpoint.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}