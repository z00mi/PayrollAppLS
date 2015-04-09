using System;
using LightSwitchApplication;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class UpdateOrganizationAssembler
    {
        public static UpdateOrganizationData DtoToArgs(DTO_AddUpdateOrganization dto)
        {
            return new UpdateOrganizationData
            {
                OrganizationUid = dto.OrganizationUid.Value,
                Name = dto.Name,
                WebAddress = dto.WebAddress
            };
        }
    }
}