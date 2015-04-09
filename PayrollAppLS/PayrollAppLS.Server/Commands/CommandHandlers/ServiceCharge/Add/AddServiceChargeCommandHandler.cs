using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class AddServiceChargeCommandHandler : CommandHandler
    {
        public AddServiceChargeCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.AddServiceCharge, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_AddServiceCharge);
            CheckPermission(Permissions.CanAddServiceCharges);

            var args = AddServiceChargeAssembler.DtoToArgs(command.DTO_AddServiceCharge);
            var uid = DependencyProvider.GetInstance<IAddServiceChargeAppService>().Invoke(args);

            command.DTO_AddServiceCharge.Result_ServiceChargeUid = uid; 
        }
    }
}