using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class UpdateOrganizationCommandHandler : CommandHandler
    {
        public UpdateOrganizationCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.UpdateOrganization, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_AddUpdateOrganization);
            CheckPermission(Permissions.CanUpdateOrganizations);

            var args = UpdateOrganizationAssembler.DtoToArgs(command.DTO_AddUpdateOrganization);
            DependencyProvider.GetInstance<IUpdateOrganizationAppService>().Invoke(args);
        }
    }
}