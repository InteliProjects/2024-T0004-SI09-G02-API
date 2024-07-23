using GTI.Dashboard.Repository;

namespace GTI.Dashboard.Services.Zenklub
{
    public class ZenklubService : IZenklubService
    {
        private readonly IZenklubRepository _zenklubRepository;

        public ZenklubService(IZenklubRepository zenklubRepository)
        {
            _zenklubRepository = zenklubRepository;
        }

        public Task<IEnumerable<ZenklubModel>> GetDepartment() => _zenklubRepository.GetDepartment();

        public Task<IEnumerable<ZenklubModel>> GetTotalSessionsByDepartment() => _zenklubRepository.GetTotalSessionsByDepartment();
    }
}
