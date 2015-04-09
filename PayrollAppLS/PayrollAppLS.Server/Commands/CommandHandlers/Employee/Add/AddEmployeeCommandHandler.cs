using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class AddEmployeeCommandHandler : CommandHandler
    {
        public AddEmployeeCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.AddEmployee, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_AddUpdateEmployee);
            CheckPermission(Permissions.CanAddEmployees);

            var args = AddEmployeeAssembler.DtoToArgs(command.DTO_AddUpdateEmployee);
            var uid = DependencyProvider.GetInstance<IAddEmployeeAppService>().Invoke(args);

            command.DTO_AddUpdateEmployee.EmployeeUid = uid; //Result
        }
    }
}