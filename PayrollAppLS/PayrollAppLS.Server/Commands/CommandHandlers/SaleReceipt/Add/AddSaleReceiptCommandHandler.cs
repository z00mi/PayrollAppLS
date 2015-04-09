using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class AddSaleReceiptCommandHandler : CommandHandler
    {
        public AddSaleReceiptCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.AddSaleReceipt, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_AddSaleReceipt);
            CheckPermission(Permissions.CanAddSaleReceipts);

            var args = AddSaleReceiptAssembler.DtoToArgs(command.DTO_AddSaleReceipt);
            var uid = DependencyProvider.GetInstance<IAddSaleReceiptAppService>().Invoke(args);

            command.DTO_AddSaleReceipt.Result_SaleReceiptUid = uid; 
        }
    }
}