using GTI.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI.Dashboard.Services.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<IEnumerable<OrganizationModel>> GetOrganizations() => await _organizationRepository.GetOrganizations();
        public async Task<IEnumerable<OrganizationModel>> GetOrganizationsUnits() => await _organizationRepository.GetOrganizationsUnits();
    }
}