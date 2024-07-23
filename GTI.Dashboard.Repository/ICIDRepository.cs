using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public interface ICIDRepository
    {
        Task<IEnumerable<CIDModel>> GetCID();
        Task<IEnumerable<CIDModel>> GetCauseByHealthUnit(string unidade);
        Task<IEnumerable<CIDModel>> GetDoctorCertificateQuantity();
        Task<int> InsertEmployee(CIDModel cidModel);
        Task<int> UpdateEmployee(CIDModel cidModel);
    }
}
