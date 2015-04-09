using System;
using PayrollApp.Shared;

namespace LightSwitchApplication.UserCode
{

    public interface ICommandFactory
    {
        DTO_AddUpdateOrganization CreateAddOrganizationCommandDTO();
        DTO_AddUpdateOrganization CreateUpdateOrganizationCommandDTO(Organization editedOrganizationData);
        DTO_Delete CreateDeleteOrganizationCommandDTO(Guid organizationUid);
    }


    public class CommandFactory : ICommandFactory
    {

        #region Organization

        public DTO_AddUpdateOrganization CreateAddOrganizationCommandDTO()
        {
            return new DTO_AddUpdateOrganization
            {
                Command = new Command { Name = CommandNames.AddOrganization }
            };
        }

        public DTO_AddUpdateOrganization CreateUpdateOrganizationCommandDTO(Organization editedOrganizationData)
        {
            var cmdAddUpdateOrganization = new DTO_AddUpdateOrganization
            {
                OrganizationUid = editedOrganizationData.Uid,
                Name = editedOrganizationData.Name,
                WebAddress = editedOrganizationData.WebAddress,
                Command = new Command { Name = CommandNames.UpdateOrganization }
            };
            return cmdAddUpdateOrganization;
        }

        public DTO_Delete CreateDeleteOrganizationCommandDTO(Guid organizationUid)
        {
            return new DTO_Delete
            {
                AggregateUid = organizationUid,
                Command = new Command { Name = CommandNames.DeleteOrganization }
            };
        }
        
        #endregion



    }
}
