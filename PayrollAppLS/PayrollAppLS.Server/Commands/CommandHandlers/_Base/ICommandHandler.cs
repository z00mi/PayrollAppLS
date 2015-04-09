using LightSwitchApplication;
using Microsoft.LightSwitch;

namespace Infrastructure.CommandHandlers
{
    public interface ICommandHandler
    {
        /// <summary>
        /// Nazwa komendy
        /// </summary>
        string CommandName { get; }

        /// <summary>
        /// Wywyołuje handler komendy. 
        /// </summary>
        /// <exception cref="PermissionException">Jeśli brak uprawnień to PermissionException</exception>
        /// <param name="command">Komenda</param>
        void Execute(Command command);
    }
}