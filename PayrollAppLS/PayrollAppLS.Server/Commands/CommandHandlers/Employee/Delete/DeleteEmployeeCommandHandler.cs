using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class DeleteEmployeeCommandHandler : CommandHandler
    {
        public DeleteEmployeeCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.DeleteEmployee, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_Delete);
            CheckPermission(Permissions.CanDeleteEmployees);

            DependencyProvider.GetInstance<IDeleteEmployeeAppService>().Invoke(command.DTO_Delete.AggregateUid);
        }
    }
}