using System.Threading.Tasks;

namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Defines a handler for a command
    /// Represents <see cref="IAsyncCommandHandler"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TCommand">The type of command object being handled</typeparam>
    public interface IAsyncCommandHandler<TCommand>
        where TCommand : Command
    {
        /// <summary>
        /// Handles a Command asynchronously
        /// </summary>
        /// <param name="command">The command object to be handled</param>
        Task HandleAsync(TCommand command);
    }

}