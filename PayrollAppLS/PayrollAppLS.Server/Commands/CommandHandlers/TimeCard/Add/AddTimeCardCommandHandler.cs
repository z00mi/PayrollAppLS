using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class AddTimeCardCommandHandler : CommandHandler
    {
        public AddTimeCardCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.AddTimeCard, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_AddTimeCard);
            CheckPermission(Permissions.CanAddTimeCards);

            var args = AddTimeCardAssembler.DtoToArgs(command.DTO_AddTimeCard);
            var uid = DependencyProvider.GetInstance<IAddTimeCardAppService>().Invoke(args);

            command.DTO_AddTimeCard.Result_TimeCardUid = uid; 
        }
    }
}