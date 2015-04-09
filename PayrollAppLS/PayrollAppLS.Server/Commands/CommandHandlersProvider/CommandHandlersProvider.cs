using System;
using System.Collections.Generic;
using System.Linq;
using PayrollApp.Infrastructure.IoC;

namespace Infrastructure.CommandHandlers
{
    public class CommandHandlersProvider: ICommandHandlersProvider
    {
        private readonly IEnumerable<ICommandHandler> _commandHandlers; 


        public static ICommandHandlersProvider Instance = new CommandHandlersProvider();

        private CommandHandlersProvider()
        {
            _commandHandlers = DependencyProvider.Instance.GetAllInstances<ICommandHandler>();
        }

        public ICommandHandler GetCommandHandler(string commandName)
        {
            var commandHandler = _commandHandlers.FirstOrDefault(h => h.CommandName == commandName);
            if(commandHandler == null)
                throw new NotSupportedException(string.Format("Unknown Command '{0}'", commandName));

            return commandHandler;
        }
    }
}