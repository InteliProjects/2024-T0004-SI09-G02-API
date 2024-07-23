using GTI.Dashboard.Repository;

namespace GTI.Dashboard.Services.CID
{
    public interface ICIDService
    {
        Task<IEnumerable<CIDModel>> GetCID();
        Task<IEnumerable<CIDModel>> GetCauseByHealthUnit(string unidade);
        Task<IEnumerable<CIDModel>> GetDoctorCertificateQuantity();
        Task<int> InsertEmployee(CIDModel cidModel);
        Task<int> UpdateEmployee(CIDModel cidModel);
    }
}
