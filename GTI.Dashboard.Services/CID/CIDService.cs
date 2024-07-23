using GTI.Dashboard.Repository;

namespace GTI.Dashboard.Services.CID
{
    public class CIDService : ICIDService
    {
        private readonly ICIDRepository _cidRepository;

        public CIDService(ICIDRepository cidRepository)
        {
            _cidRepository = cidRepository;
        }

        public async Task<IEnumerable<CIDModel>> GetCauseByHealthUnit(string unidade) => await _cidRepository.GetCauseByHealthUnit(unidade);

        public async Task<IEnumerable<CIDModel>> GetCID() => await _cidRepository.GetCID();

        public async Task<IEnumerable<CIDModel>> GetDoctorCertificateQuantity() => await _cidRepository.GetDoctorCertificateQuantity();


        public Task<int> InsertEmployee(CIDModel cidModel)
        {

            throw new NotImplementedException();
        }

        public Task<int> UpdateEmployee(CIDModel cidModel)
        {
            throw new NotImplementedException();
        }
    }
}
