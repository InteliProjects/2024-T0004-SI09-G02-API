using GTI.Dashboard.Repository;
using GTI.Dashboard.Services.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Services.Stiba
{
    public class StibaService : IStibaService
    {
        private readonly IStibaRepository _stibaRepository;
        public StibaService(IStibaRepository stibaRepository)
        {
            _stibaRepository = stibaRepository;
        }

        public Task<IEnumerable<StibaModel>> GetStibas() => _stibaRepository.GetStibas();
    }
}