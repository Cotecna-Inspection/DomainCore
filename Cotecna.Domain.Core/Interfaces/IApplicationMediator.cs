namespace Cotecna.Domain.Core.Interfaces
{
    /// <summary>
    /// Defines a mediator to encapsulate command and querys.
    /// Represents <see cref="IApplicationMediator"/> Injectable Service Interface
    /// </summary>
    public interface IApplicationMediator
    {
        /// <summary>
        /// Manage comand objects
        /// </summary>
        /// <typeparam name="ICommand"> <see cref="ICommand"/></typeparam>
        /// <param name="command">Command object to be dispatched</param>
        /// <returns>Returns boolean if Command was correctly dispatched</returns>
        bool Dispatch(ICommand command);

        /// <summary>
        /// Manage comand objects
        /// </summary>
        /// <typeparam name="IQuery"> <see cref="IQuery"/></typeparam>
        /// <param name="query">Query object to be dispatched</param>
        /// <returns>Result object</returns>
        T Dispatch<T>(IQuery<T> query);
    }
}
