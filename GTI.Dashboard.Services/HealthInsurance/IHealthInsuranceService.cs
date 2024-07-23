using GTI.Dashboard.Repository;

namespace GTI.Dashboard.Services.HealthInsurance
{
    public interface IHealthInsuranceService
    {
        Task<IEnumerable<HealthInsuranceModel>> GetHealthInsurances();
        Task<HealthInsuranceModel> GetHealthInsuranceById(int id);
        Task<string> GetPlanByCodigoPaciente(int CodigoPaciente);
        Task<IEnumerable<HealthInsuranceModel>> GetProcedures();
        Task<IEnumerable<HealthInsuranceModel>> GetEventOccurrences();
        Task<IEnumerable<HealthInsuranceModel>> GetAppointmentsQuantity();
        Task<IEnumerable<HealthInsuranceModel>> GetDaysAppointment();
        Task<IEnumerable<HealthInsuranceModel>> GetAppointmentSpeciality();
    }
}
