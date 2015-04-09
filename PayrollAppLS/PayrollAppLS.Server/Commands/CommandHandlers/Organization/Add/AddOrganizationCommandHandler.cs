using LightSwitchApplication;
using Microsoft.LightSwitch;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class AddOrganizationCommandHandler : CommandHandler
    {
        public AddOrganizationCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.AddOrganization, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_AddUpdateOrganization);
            CheckPermission(Permissions.CanAddOrganizations);

            var args = AddOrganizationAssembler.DtoToArgs(command.DTO_AddUpdateOrganization);
            var uid = DependencyProvider.GetInstance<IAddOrganizationAppService>().Invoke(args);

            command.DTO_AddUpdateOrganization.OrganizationUid = uid; //Result
        }
    }
}