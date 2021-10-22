namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Defines a handler for a command
    /// Represents <see cref="ICommandHandler"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TCommand">The type of command object being handled</typeparam>
    public interface ICommandHandler<TCommand>
        where TCommand : Command
    {
        /// <summary>
        /// Handles a Command
        /// </summary>
        /// <param name="command">The command object to be handled</param>
        void Handle(TCommand command);
    }
}
