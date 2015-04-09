using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class UpdateAffiliationCommandHandler : CommandHandler
    {
        public UpdateAffiliationCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.UpdateAffiliation, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_UpdateAffiliation);
            CheckPermission(Permissions.CanUpdateAffiliations);

            var args = UpdateAffiliationAssembler.DtoToArgs(command.DTO_UpdateAffiliation);
            DependencyProvider.GetInstance<IUpdateAffiliationAppService>().Invoke(args);
        }
    }
}