using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class DeleteTimeCardCommandHandler : CommandHandler
    {
        public DeleteTimeCardCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.DeleteTimeCard, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_Delete);
            CheckPermission(Permissions.CanDeleteTimeCards);

            DependencyProvider.GetInstance<IDeleteTimeCardAppService>().Invoke(command.DTO_Delete.AggregateUid);
        }
    }
}