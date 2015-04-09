using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class DeleteSaleReceiptCommandHandler : CommandHandler
    {
        public DeleteSaleReceiptCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.DeleteSaleReceipt, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_Delete);
            CheckPermission(Permissions.CanDeleteSaleReceipts);

            DependencyProvider.GetInstance<IDeleteSaleReceiptAppService>().Invoke(command.DTO_Delete.AggregateUid);
        }
    }
}