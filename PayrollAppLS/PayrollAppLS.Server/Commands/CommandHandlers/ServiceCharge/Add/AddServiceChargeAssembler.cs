using System;
using LightSwitchApplication;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class AddServiceChargeAssembler
    {
        public static AddServiceChargeData DtoToArgs(DTO_AddServiceCharge dto)
        {
            return new AddServiceChargeData
            {
                OrganizationUid = dto.OrganizationUid,
                MemberId = dto.MemberId,
                Date = dto.SCDate,
                Amount = dto.Amount
            };
        }
    }
}