using GTI.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Services.Organization
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationModel>> GetOrganizations();
        Task<IEnumerable<OrganizationModel>> GetOrganizationsUnits();
    }
}