import { Command, InvokeResult } from ".";

/**
 * Defines a Asynchronous Handler for Commands.
 */
export interface CommandHandler {

/**
 * Handles a Command (Creation, Updating or Deletion Task) Asynchronously
 * @param command  Command to be invoked
 * @returns Result of the Command as Asynchronous Promise
 */
  invokeCommand<TCommand extends Command>(command: TCommand): Promise<InvokeResult>;

}
