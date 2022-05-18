import { Query, InvokeResult } from ".";

/**
 *  Defines a Asynchronous Handler for Queries.
 */
export interface QueryHandler {

/**
 * Handles a Query (Read Task) Asynchronously
 * @param query  Query to be invoked
 * @returns Result of the Query as Asynchronous Promise
 */
  invokeQuery<TQuery extends Query>(query: TQuery): Promise<InvokeResult>;

}
