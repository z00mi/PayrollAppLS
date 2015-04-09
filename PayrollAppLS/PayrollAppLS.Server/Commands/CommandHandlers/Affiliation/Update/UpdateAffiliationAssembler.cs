using System;
using LightSwitchApplication;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class UpdateAffiliationAssembler
    {
        public static UpdateAffiliationData DtoToArgs(DTO_UpdateAffiliation dto)
        {
            return new UpdateAffiliationData
            {
                AffiliationUid = dto.AffiliationUid,
                MemberId = dto.MemberId,
                Dues = dto.Dues
            };
        }
    }
}