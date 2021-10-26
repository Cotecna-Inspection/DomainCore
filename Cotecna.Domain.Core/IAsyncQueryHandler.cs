using System.Threading.Tasks;

namespace Cotecna.Domain.Core
{

    /// <summary>
    /// Defines a handler for an asynchronous query
    /// Represents <see cref="IQueryHandler"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TQuery">The type of query object being handled</typeparam>
    /// <typeparam name="TResult">The type of result object from the handler</typeparam>
    public interface IAsyncQueryHandler<TQuery, TResult>
        where TQuery : Query<TResult>
    {
        /// <summary>
        /// Handles an asynchronous Query
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>Result from the request</returns>
        Task<TResult> HandleAsync(TQuery query);
    }

}
