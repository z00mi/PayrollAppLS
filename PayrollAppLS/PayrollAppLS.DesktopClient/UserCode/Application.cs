using LightSwitchApplication.UserCode;

namespace LightSwitchApplication
{
    public partial class Application
    {
        private ICommandFactory _commandFactory;

        public ICommandFactory CommandFactory
        {
            get
            {
                if (_commandFactory == null)
                    _commandFactory = new CommandFactory();
                return _commandFactory;
            }
        }


        partial void OrganizationsListDetail_CanRun(ref bool result)
        {
            // Set result to the desired field value

        }
    }
}
