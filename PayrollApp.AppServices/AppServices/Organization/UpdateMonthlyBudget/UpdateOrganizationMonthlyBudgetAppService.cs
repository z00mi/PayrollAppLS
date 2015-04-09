using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.Domain.Repositories;
using PayrollApp.Domain.Services;

namespace PayrollApp.AppServices
{
    public class UpdateOrganizationMonthlyBudgetAppService : IUpdateOrganizationMonthlyBudgetAppService
    {
        private readonly IOrganizationsRepository _organizationsRepository;
        private readonly IOrganizationsService _organizationsService;

        public UpdateOrganizationMonthlyBudgetAppService(
            IOrganizationsRepository organizationsRepository,
            IOrganizationsService organizationsService)
        {
            _organizationsRepository = organizationsRepository;
            _organizationsService = organizationsService;
        }

        public void Invoke(Guid organizationUid)
        {
            var organization = _organizationsRepository.Get(organizationUid);

            organization.UpdateMonthlyBudget(_organizationsService);

            _organizationsRepository.Update(organization);
            _organizationsRepository.Save();
        }
    }
}
