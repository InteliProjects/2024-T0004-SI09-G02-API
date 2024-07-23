using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public interface IStibaRepository
    {
        Task<IEnumerable<StibaModel>> GetStibas();

    }
}
