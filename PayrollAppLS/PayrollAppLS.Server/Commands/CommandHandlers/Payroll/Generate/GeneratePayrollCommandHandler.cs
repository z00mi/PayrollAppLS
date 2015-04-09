using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class GeneratePayrollCommandHandler : CommandHandler
    {
        public GeneratePayrollCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.GeneratePayroll, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_GeneratePayroll);
            CheckPermission(Permissions.CanGeneratePayrolls);

            var uid = DependencyProvider.GetInstance<IGeneratePayrollAppService>().Invoke(command.DTO_GeneratePayroll.ForDate);

            command.DTO_GeneratePayroll.Result_PayrollUid = uid;
        }
    }
}