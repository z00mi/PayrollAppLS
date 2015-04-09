using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class DeleteOrganizationCommandHandler : CommandHandler
    {
        public DeleteOrganizationCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.DeleteOrganization, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_Delete);
            CheckPermission(Permissions.CanDeleteOrganizations);

            DependencyProvider.GetInstance<IDeleteOrganizationAppService>().Invoke(command.DTO_Delete.AggregateUid);
        }
    }
}