using GTI.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Services.GPTW
{
    public class GPTWService:IGPTWService
    {
        private readonly IGPTWRepository _gptwRepository;

        public GPTWService(IGPTWRepository gptwrepository)
        {
            _gptwRepository = gptwrepository;
        }
        public async Task<IEnumerable<GPTWModel>> GetGPTW() => await _gptwRepository.GetGPTWs();
        public async Task<IEnumerable<GPTWModel>> GetEngagement() => await _gptwRepository.GetEngagement();
        public async Task<IEnumerable<GPTWModel>> GetQuestions() => await _gptwRepository.GetQuestions();
    }
}