namespace Cotecna.Domain.Core
{

    /// <summary>
    /// Defines a Synchronous Handler for Queries.
    /// Represents <see cref="IQueryHandler{TQuery,TResult}"/> Injectable Service Interface
    /// </summary>
    /// <typeparam name="TQuery">The type of query object being handled</typeparam>
    /// <typeparam name="TResult">The type of result object from the handler</typeparam>
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : Query<TResult>
    {
        /// <summary>
        /// Handles a <see cref="TQuery"/> Synchronously
        /// </summary>
        /// <param name="query">The <see cref="TQuery"/> to be handled</param>
        /// <returns>Result of the <see cref="TQuery"/></returns>
        TResult Handle(TQuery query);
    }

}
