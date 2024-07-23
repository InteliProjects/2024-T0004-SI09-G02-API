using GTI.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Services.GPTW
{
    public interface IGPTWService
    {
        Task<IEnumerable<GPTWModel>> GetGPTW();
        Task<IEnumerable<GPTWModel>> GetEngagement();
        Task<IEnumerable<GPTWModel>> GetQuestions();
    }
}
