namespace Cotecna.Domain.Core
{

    /// <summary>
    /// Represents <see cref="IQuery"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TResult">Result type</typeparam>
    public interface IQuery<TResult> { }



    /// <summary>
    /// Defines a handler for a query
    /// Represents <see cref="IQueryHandler"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TQuery">The type of query object being handled</typeparam>
    /// <typeparam name="TResult">The type of result object from the handler</typeparam>
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Handles a Query
        /// </summary>
        /// <param name="query">The query</param>
         /// <returns>Result from the request</returns>
        TResult Handle(TQuery query);
    }

}