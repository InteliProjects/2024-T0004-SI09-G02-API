using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public interface IGPTWRepository
    {
        Task<IEnumerable<GPTWModel>> GetGPTWs();
        Task<IEnumerable<GPTWModel>> GetEngagement();
        Task<IEnumerable<GPTWModel>> GetQuestions();
    }
}
