import { Command, InvokeResult } from ".";

export interface CommandHandler {

  invokeCommand<TCommand extends Command>(command: TCommand): Promise<InvokeResult>;

}
