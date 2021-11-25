# DomainCore

The intention of the project is to create code without third-party dependencies, useful for any project that wants to follow a DDD structure in conjunction with CQRS.

[![Build Status](https://cotecna.visualstudio.com/Cotecna%20Academy/_apis/build/status/OpenSource/%5BOpenSource%5D%20-%20Domain.Core%20(NuGet)?branchName=main)](https://cotecna.visualstudio.com/Cotecna%20Academy/_build/latest?definitionId=579&branchName=main)
[![Build Status](https://cotecna.visualstudio.com/Cotecna%20Academy/_apis/build/status/OpenSource/%5BOpenSource%5D%20-%20Domain.Core.Configuration%20(NuGet)?branchName=main)](https://cotecna.visualstudio.com/Cotecna%20Academy/_build/latest?definitionId=583&branchName=main)

## Getting started

### .Net NuGet package

1. Install Domain package at your Domain layer: 
    > Install-Package Cotecna.Domain.Core
2. Install Configuration pacakge at your API or frontier layer
    > Install-Package Cotecna.Domain.Core.Configuration


For CQRS implementation examples, using commands or queries, check the examples provided [here](https://github.com/Cotecna-Inspection/Domain.Core/tree/main/Cotecna.Domain.Core.Test)

#### Queries quick overview:
1. Create a query class, inheriting from Query<TResult> where TResult is the class that will be sent back.
  ```csharp
  public class Query : Query<string>
  {
      public string Test { get; set; }
  }
  ```
2. Create a query handler class, implementing IQueryHandler<TQuery, TResult> or IAsyncQueryHandler<TQuery, TResult> where TQuery is the class created above and TResult the objet to be sent back.
  ```csharp
  public class AsyncQueryHandler : IAsyncQueryHandler<Query, string>
  {
      public async Task<string> HandleAsync(Query query)
      {
          await Task.Delay(2);
          return query.Test;
      }
  }
  ``` 
3. At startup level, register the handler
  ```csharp
  services
    .AddMediator()
    //More handlers here
    .AddAsyncQueryHandler<Query, AsyncQueryHandler, string>();
  ```
  
#### Quick commands overview

1. Create a command class, inheriting from Command
  ```csharp
  public class TestCommand : Command
  {
      public string Test { get; set; }
  }
  ```
2. Create a command handler class, implementing ICommandHandler<TCommand>, IAsyncCommandHandler<TCommand, TResult> or IAsyncCommandHandler<TCommand, TResult> where TCommand is the class created above and TResult the objet to be sent back if required.
  ```csharp
  public class AsyncCommandHandler : IAsyncCommandHandler<TestCommand>
  {
      public async Task HandleAsync(TestCommand command)
      {
          await Task.Delay(2);
          TestResult = command.Test;
      }

      public static string TestResult { get; set; }
  }
  ``` 
3. At startup level, register the handler
  ```csharp
  services
    .AddMediator()
    //More handlers here
    .AddAsyncCommandHandler<TestCommand, AsyncCommandHandler>();
  ```
  
#### Invoke handlers from IApplicationMediator
In every scenario, what will be required is to inject IApplicationMediator in your application or services layer, and then call Dispatch methods (overloaded) for both cases:
  ```csharp
  var result = mediator.DispatchAsync(query);
   
  ///
  
  await mediator.DispatchAsync(command);
  
  ```
  
Additionally, synchronous handlers are allowed, so no need to do it async


## TypeScript npm package

This package tries to follow the principle of task-based UI, aligned with CQRS pattern at the backend level.

1. Install Domain package at your Domain layer: 
    > npm i @cotecna/domain-core
	
2. The package exposes basic query and command interfaces, as well as their respective handlers that must be implemented in the services exposing only the invokeQuery and/or invoqueCommand methods

	```javascript
	
	// Example command
	export class ExampleCommand implements Command
	{
		test: string;
	}
	
	// Example query
	export class ExampleQuery implements Query
	{
		test: string;
	}
	
	
	// Example service in Angular
	
	@Injectable({
	  providedIn: 'root'
	})
	export class ExampleService implements QueryHandler, CommandHandler {

		// Subscriptions, variables, etc goes here
    ///

		constructor(private httpClient: HttpClient) { }


		public invokeCommand<TCommand extends Command>(command: TCommand): Promise<InvokeResult> {
			switch(command.constructor) {
				case ExampleCommand:
					return this.invokeExampleCommand(command); // Private method implemented in this class
				//More commands handling here...
				default:
					throw new Error("Command not allowed");
			}
		}
	  
		public async invokeQuery<TQuery extends Query>(query: TQuery): Promise<InvokeResult> {
			switch(query.constructor) {
				case ExampleQuery:
					return this.invokeExampleQuery(query); // Private method implemented in this class
				//More queries handling here...
				default:
					throw new Error("Query not allowed");
			}
		}

    // Private methods implementation goes here, data logic remains in the service
    ///

	}
  ```
  
  
_Thanks for using, do not hesitate to contribute_