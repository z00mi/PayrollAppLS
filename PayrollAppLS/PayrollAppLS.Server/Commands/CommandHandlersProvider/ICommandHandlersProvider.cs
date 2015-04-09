namespace Infrastructure.CommandHandlers
{
    public interface ICommandHandlersProvider
    {
        ICommandHandler GetCommandHandler(string commandName);
    }
}