using GTI.Dashboard.Repository;

namespace GTI.Dashboard.Services.HealthInsurance
{
    public class HealthInsuranceService : IHealthInsuranceService
    {
        private readonly IHealthInsuranceRepository _healthInsuranceRepository;

        public HealthInsuranceService(IHealthInsuranceRepository healthInsuranceRepository)
        {
            _healthInsuranceRepository = healthInsuranceRepository;
        }

        public async Task<HealthInsuranceModel> GetHealthInsuranceById(int id) => await _healthInsuranceRepository.GetHealthInsuranceById(id);

        public async Task<IEnumerable<HealthInsuranceModel>> GetHealthInsurances() => await _healthInsuranceRepository.GetHealthInsurances();

        public Task<string> GetPlanByCodigoPaciente(int CodigoPaciente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HealthInsuranceModel>> GetProcedures()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<HealthInsuranceModel>> GetEventOccurrences() => await _healthInsuranceRepository.GetEventOccurrences();

        public async Task<IEnumerable<HealthInsuranceModel>> GetAppointmentsQuantity() => await _healthInsuranceRepository.GetAppointmentsQuantity(); 
        public async Task<IEnumerable<HealthInsuranceModel>> GetDaysAppointment() => await _healthInsuranceRepository.GetDaysAppointment();
        public async Task<IEnumerable<HealthInsuranceModel>> GetAppointmentSpeciality() => await _healthInsuranceRepository.GetAppointmentSpeciality();
    }
}
