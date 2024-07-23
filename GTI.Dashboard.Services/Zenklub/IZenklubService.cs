using GTI.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Services.Zenklub
{
    public interface IZenklubService
    {
        Task<IEnumerable<ZenklubModel>> GetDepartment();
        Task<IEnumerable<ZenklubModel>> GetTotalSessionsByDepartment();
    }
}
