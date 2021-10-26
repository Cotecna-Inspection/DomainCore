namespace Cotecna.Domain.Core
{

    /// <summary>
    /// Defines a handler for a query
    /// Represents <see cref="IQueryHandler"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TQuery">The type of query object being handled</typeparam>
    /// <typeparam name="TResult">The type of result object from the handler</typeparam>
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : Query<TResult>
    {
        /// <summary>
        /// Handles a Query
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>Result from the request</returns>
        TResult Handle(TQuery query);
    }

}
