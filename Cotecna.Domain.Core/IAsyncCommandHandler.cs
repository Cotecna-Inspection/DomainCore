using System.Threading.Tasks;

namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Defines an Asynchronous Handler for Commands
    /// Represents <see cref="IAsyncCommandHandler{TCommand}"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TCommand">The type of command object being handled</typeparam>
    public interface IAsyncCommandHandler<TCommand>
        where TCommand : Command
    {
        /// <summary>
        /// Handles a <see cref="TCommand"/> Asynchronously
        /// </summary>
        /// <param name="command">The <see cref="TCommand"/> to be handled</param>
        Task HandleAsync(TCommand command);

    }

    /// <summary>
    /// Defines an Asynchronous Handler for Commands
    /// Represents <see cref="IAsyncCommandHandler{TCommand}"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TCommand">The type of command object being handled</typeparam>
    public interface IAsyncCommandHandler<TCommand,TResult>
        where TCommand : Command<TResult>
    {        

        /// <summary>
        /// Handles a <see cref="TCommand"/> Asynchronously
        /// </summary>
        /// <param name="command">The <see cref="TCommand"/> to be handled</param>
        /// <returns>Result <see cref="Task{TResult}"/> object</returns>
        Task<TResult> HandleAsync(TCommand command);
    }

}