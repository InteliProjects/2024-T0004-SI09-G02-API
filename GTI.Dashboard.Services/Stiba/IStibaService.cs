using GTI.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Services.Stiba
{
    public interface IStibaService
    {
        Task<IEnumerable<StibaModel>> GetStibas();
    }
}