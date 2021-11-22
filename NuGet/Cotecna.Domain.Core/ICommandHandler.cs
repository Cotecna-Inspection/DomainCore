namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Defines a Synchronous Handler for Commands.
    /// Represents <see cref="ICommandHandler{TCommand}"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TCommand">Type of the command being handled</typeparam>
    public interface ICommandHandler<TCommand>
        where TCommand : Command
    {
        /// <summary>
        /// Handles a <see cref="TCommand"/> Synchronously
        /// </summary>
        /// <param name="command">The <see cref="TCommand"/> to be handled</param>
        void Handle(TCommand command);
    }
}
