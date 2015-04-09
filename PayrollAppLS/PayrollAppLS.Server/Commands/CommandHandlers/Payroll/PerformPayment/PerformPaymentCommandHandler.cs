using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class PerformPaymentCommandHandler : CommandHandler
    {
        public PerformPaymentCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.PerformPayment, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_PerformPayment);
            CheckPermission(Permissions.CanPerformPayments);

            DependencyProvider.GetInstance<IPerformPaymentAppService>().Invoke(command.DTO_PerformPayment.PayrollUid);
        }
    }
}