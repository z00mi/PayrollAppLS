using System;
using Infrastructure.CommandHandlers;
using Microsoft.LightSwitch;
using PayrollApp.EventHandlers;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Infrastructure.MessageBus;

namespace LightSwitchApplication
{
    public partial class ApplicationDataService
    {
        private static IMessagePublisher _messagePublisher;

        private static IMessagePublisher MessagePublisher
        {
            get
            {
                if (_messagePublisher == null)
                    _messagePublisher = DependencyProvider.Instance.GetInstance<IMessagePublisher>();
                return _messagePublisher;
            }
        }


        /// <summary>
        /// Transaction start
        /// </summary>
        partial void SaveChanges_Executing()
        {
            MessagePublisher.ClearBufferedMessages();
        }

        partial void Commands_Inserting(Command command)
        {
            try
            {
                var commandHandler = CommandHandlersProvider.Instance.GetCommandHandler(command.Name);
                commandHandler.Execute(command);
            }
            catch (PayrollApp.Domain.Exceptions.ValidationException vex)
            {
                throw new ValidationException(vex.Message);
            }
            catch (PermissionException pex)
            {
                throw new ValidationException("Błąd autoryzacji|Brak uprawnień do wykonania komendy");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Transaction success
        /// </summary>
        partial void SaveChanges_Executed()
        {
            MessagePublisher.FlushBufferedMessages();
        }

        /// <summary>
        /// Transaction failed
        /// </summary>
        partial void SaveChanges_ExecuteFailed(Exception exception)
        {
            MessagePublisher.ClearBufferedMessages();
        }
    }
}
