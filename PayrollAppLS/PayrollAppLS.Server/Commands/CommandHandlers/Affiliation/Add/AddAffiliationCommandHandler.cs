using LightSwitchApplication;
using PayrollApp.AppServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Shared;

namespace Infrastructure.CommandHandlers
{
    public class AddAffiliationCommandHandler : CommandHandler
    {
        public AddAffiliationCommandHandler(IDependencyProvider dependencyProvider)
            : base(CommandNames.AddAffiliation, dependencyProvider)
        {
        }

        public override void Execute(Command command)
        {
            CheckCommandNotNull(command, command.DTO_AddAffiliation);
            CheckPermission(Permissions.CanAddAffiliations);

            var args = AddAffiliationAssembler.DtoToArgs(command.DTO_AddAffiliation);
            var uid = DependencyProvider.GetInstance<IAddAffiliationAppService>().Invoke(args);

            command.DTO_AddAffiliation.Result_AffiliationUid = uid; 
        }

    }
}