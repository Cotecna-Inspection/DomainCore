import { Query, InvokeResult } from ".";

export interface QueryHandler {

  invokeQuery<TQuery extends Query>(query: TQuery): Promise<InvokeResult>;

}
