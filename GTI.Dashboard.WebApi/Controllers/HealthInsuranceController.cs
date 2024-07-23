using Microsoft.AspNetCore.Mvc;
using GTI.Dashboard.Services.HealthInsurance;
using System.Threading.Tasks;
using Serilog;

namespace GTI.Dashboard.WebApi.Controllers
{
    [Route("api/health-insurance")]
    [ApiController]
    public class HealthInsuranceController : ControllerBase
    {
        private readonly IHealthInsuranceService _healthInsuranceService;

        public HealthInsuranceController(IHealthInsuranceService healthInsuranceService)
        {
            _healthInsuranceService = healthInsuranceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHealthInsurances()
        {

            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information() 
                    .WriteTo.Console() 
                    .CreateLogger();

                Log.Information("GET request received for GetHealthInsurances endpoint.");

                Log.Information("GET request processed successfully for GetHealthInsurances endpoint.");

                return Ok(await _healthInsuranceService.GetHealthInsurances());

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing GET request for GetHealthInsurances endpoint.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHealthInsuranceById([FromRoute] int id)
        {
            var healthInsurance = await _healthInsuranceService.GetHealthInsuranceById(id);
            if (healthInsurance == null)
            {
                return NotFound("Plano de saúde não encontrado no sistema.");
            }
            return Ok(healthInsurance);
        }
        [Route("/event_occurrences")]
        [HttpGet]
        public async Task<IActionResult> GetEventOccurrences()
        {
            return Ok( await _healthInsuranceService.GetEventOccurrences());
        }

        [Route("/appointments_quantity")]
        [HttpGet]
        public async Task<IActionResult> GetAppointmentsQuantity()
        {
            return Ok(await _healthInsuranceService.GetAppointmentsQuantity());
        }

        [Route("/days_appointment")]
        [HttpGet]
        public async Task<IActionResult> GetDaysAppointment()
        {
            return Ok(await _healthInsuranceService.GetDaysAppointment());
        }

        [Route("/appointment_speciality")]
        [HttpGet]
        public async Task<IActionResult> GetAppointmentSpeciality()
        {
            return Ok(await _healthInsuranceService.GetAppointmentSpeciality());
            //return Ok(health_insurance);
        }
    }
}
