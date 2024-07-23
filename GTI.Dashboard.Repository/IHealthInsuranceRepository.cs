namespace GTI.Dashboard.Repository
{
    public interface IHealthInsuranceRepository
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
