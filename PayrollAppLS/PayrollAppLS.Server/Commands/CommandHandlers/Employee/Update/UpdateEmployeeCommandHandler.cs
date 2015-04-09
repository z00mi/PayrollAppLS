using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class UpdateEmployeeCommandHandler : CommandHandler
    {
        public UpdateEmployeeCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.UpdateEmployee, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_AddUpdateEmployee);
            CheckPermission(Permissions.CanUpdateEmployees);

            var args = UpdateEmployeeAssembler.DtoToArgs(command.DTO_AddUpdateEmployee);
            DependencyProvider.GetInstance<IUpdateEmployeeAppService>().Invoke(args);
        }
    }
}