import { Query, InvokeResult } from ".";

/**
 *  Defines a Synchronous Handler for Queries.
 */
export interface QueryHandler {

/**
 * Handles a Query (Read Operation) Asynchronously
 * @param query  Query to be invoked
 * @returns Result of the Query as Asynchronous Promise
 */
  invokeQuery<TQuery extends Query>(query: TQuery): Promise<InvokeResult>;

}
