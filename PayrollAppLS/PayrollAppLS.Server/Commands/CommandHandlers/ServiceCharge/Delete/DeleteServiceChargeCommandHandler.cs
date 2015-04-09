using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class DeleteServiceChargeCommandHandler : CommandHandler
    {
        public DeleteServiceChargeCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.DeleteServiceCharge, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_Delete);
            CheckPermission(Permissions.CanDeleteServiceCharges);

            DependencyProvider.GetInstance<IDeleteServiceChargeAppService>().Invoke(command.DTO_Delete.AggregateUid);
        }
    }
}