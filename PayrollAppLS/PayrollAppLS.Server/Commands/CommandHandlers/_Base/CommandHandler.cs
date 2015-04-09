using System;
using LightSwitchApplication;
using PayrollApp.Infrastructure.IoC;

namespace Infrastructure.CommandHandlers
{
    public abstract class CommandHandler: ICommandHandler
    {
        private readonly string _commandName;
        protected IDependencyProvider DependencyProvider { get; private set; }

        protected CommandHandler(string commandName, IDependencyProvider dependencyProvider)
        {
            _commandName = commandName;
            DependencyProvider = dependencyProvider;
        }

        public string CommandName
        {
            get { return _commandName; }
        }

        protected void CheckCommandNotNull<T>(Command command, T commandDetails)
        {
            if (commandDetails == null)
                throw new Exception("Invalid DTO for Command: " +  command.Name);
        }

        protected void CheckPermission(string permission)
        {
            Application.Current.User.DemandPermission(permission);
        }

        public abstract void Execute(Command command);
    
    }
}