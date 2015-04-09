using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class UpdatePayrollStatusCommandHandler : CommandHandler
    {
        public UpdatePayrollStatusCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.UpdatePayrollStatus, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_UpdatePayrollStatus);
            CheckPermission(Permissions.CanUpdatePayrollStatuses);

            var args = UpdatePayrollStatusAssembler.DtoToArgs(command.DTO_UpdatePayrollStatus);
            DependencyProvider.GetInstance<IUpdatePayrollStatusAppService>().Invoke(args);
        }
    }
}