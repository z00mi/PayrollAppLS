using System;
using LightSwitchApplication;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class AddAffiliationAssembler
    {
        public static AddAffiliationData DtoToArgs(DTO_AddAffiliation dto)
        {
            return new AddAffiliationData
            {
                EmployeeUid = dto.EmployeeUid,
                OrganizationUid = dto.OrganizationUid,
                MemberId = dto.MemberId,
                Dues = dto.Dues
            };
        }
    }
}