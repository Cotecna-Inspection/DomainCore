namespace Cotecna.Domain.Core
{

    /// <summary>
    /// Represents <see cref="ICommand"/> Injectable Service Interface
    /// </summary>
    public interface ICommand { }



    /// <summary>
    /// Defines a handler for a command
    /// Represents <see cref="ICommandHandler"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TCommand">The type of command object being handled</typeparam>
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        /// <summary>
        /// Handles a Command
        /// </summary>
        /// <param name="command">The command object to be handled</param>
        /// <returns>If command has been handled correctly</returns>
        bool Handle(TCommand command);
    }

}