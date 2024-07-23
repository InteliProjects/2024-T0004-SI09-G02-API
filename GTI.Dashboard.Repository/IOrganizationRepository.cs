using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Repository
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<OrganizationModel>> GetOrganizations();
        Task<IEnumerable<OrganizationModel>> GetOrganizationsUnits();
    }
}