using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class DeletePayrollCommandHandler : CommandHandler
    {
        public DeletePayrollCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.DeletePayroll, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_Delete);
            CheckPermission(Permissions.CanDeletePayrolls);

            DependencyProvider.GetInstance<IDeletePayrollAppService>().Invoke(command.DTO_Delete.AggregateUid);
        }
    }
}