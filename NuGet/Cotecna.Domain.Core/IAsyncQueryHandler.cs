using System.Threading.Tasks;

namespace Cotecna.Domain.Core
{

    /// <summary>
    /// Defines an Asynchronous Handler for Queries.
    /// Represents a <see cref="IQueryHandler{TQuery, TResult}"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TQuery">The type of query object being handled</typeparam>
    /// <typeparam name="TResult">The type of result object from the handler</typeparam>
    public interface IAsyncQueryHandler<TQuery, TResult>
        where TQuery : Query<TResult>
    {
        /// <summary>
        /// Handles a <see cref="TQuery"/> Asynchronously
        /// </summary>
        /// <param name="query">The <see cref="TQuery"/> to be handled</param>
        /// <returns>Result of the <see cref="TQuery"/></returns>
        Task<TResult> HandleAsync(TQuery query);
    }

}
