using System;
using LightSwitchApplication;
using PayrollApp.AppServices;

namespace Infrastructure.CommandHandlers
{
    public class AddOrganizationAssembler
    {
        public static AddOrganizationData DtoToArgs(DTO_AddUpdateOrganization dto)
        {
            return new AddOrganizationData
            {
                Name = dto.Name,
                WebAddress = dto.WebAddress
            };
        }
    }
}