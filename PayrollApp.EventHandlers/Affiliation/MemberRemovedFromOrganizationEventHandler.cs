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
    public class MemberRemovedFromOrganizationEventHandler : IHandleMessages<MemberRemovedFromOrganizationEvent>
    {
        private readonly IUpdateOrganizationMembersCountAppService _updateOrganizationMembersCountAppService;
        private readonly IUpdateOrganizationMonthlyBudgetAppService _updateOrganizationMonthlyBudgetAppService;

        public MemberRemovedFromOrganizationEventHandler(
            IUpdateOrganizationMembersCountAppService updateOrganizationMembersCountAppService,
            IUpdateOrganizationMonthlyBudgetAppService updateOrganizationMonthlyBudgetAppService)
        {
            _updateOrganizationMembersCountAppService = updateOrganizationMembersCountAppService;
            _updateOrganizationMonthlyBudgetAppService = updateOrganizationMonthlyBudgetAppService;
        }

        public void Handle(MemberRemovedFromOrganizationEvent msg)
        {
            _updateOrganizationMembersCountAppService.Invoke(msg.OrganizationUid);
            _updateOrganizationMonthlyBudgetAppService.Invoke(msg.OrganizationUid);
        }
    }
}
