using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApp.AppServices;
using PayrollApp.Domain.Events;
using PayrollApp.Domain.Repositories;
using Rebus;

namespace PayrollApp.EventHandlers
{
    public class MemberDuesChangedEventHandler : IHandleMessages<MemberDuesChangedEvent>
    {
        private readonly IUpdateOrganizationMonthlyBudgetAppService _updateOrganizationMonthlyBudgetAppService;

        public MemberDuesChangedEventHandler(
            IUpdateOrganizationMonthlyBudgetAppService updateOrganizationMonthlyBudgetAppService)
        {
            _updateOrganizationMonthlyBudgetAppService = updateOrganizationMonthlyBudgetAppService;
        }

        public void Handle(MemberDuesChangedEvent msg)
        {
            //TODO ...

            //_updateOrganizationMonthlyBudgetAppService.Invoke(msg.OrganizationUid);
        }
    }
}
