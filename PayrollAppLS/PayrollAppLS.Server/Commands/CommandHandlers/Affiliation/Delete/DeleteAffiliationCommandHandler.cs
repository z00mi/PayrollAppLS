using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class DeleteAffiliationCommandHandler : CommandHandler
    {
        public DeleteAffiliationCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.DeleteAffiliation, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_Delete);
            CheckPermission(Permissions.CanDeleteAffiliations);

            DependencyProvider.GetInstance<IDeleteAffiliationAppService>().Invoke(command.DTO_Delete.AggregateUid);
        }
    }
}