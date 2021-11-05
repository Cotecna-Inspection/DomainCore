using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace Cotecna.Domain.Core.Test
{
    public class ApplicationMediatorTests
    {
        private readonly IApplicationMediator mediator;

        public ApplicationMediatorTests()
        {
            var services = new ServiceCollection();

            services
                .AddMediator()
                .AddCommandHandler<TestCommand, CommandHandler>()
                .AddCommandAsyncHandler<AsyncTestCommand, AsyncCommandHandler>()
                .AddCommandAsyncHandler<AsyncTestCommandString,AsyncCommandHandlerString,string>()
                .AddQueryHandler<Query, QueryHandler, string>()
                .AddQueryAsyncHandler<AsyncQuery, AsyncQueryHandler, string>();

            var serviceProvider = services.BuildServiceProvider();

            mediator = serviceProvider.GetService<IApplicationMediator>();
        }


        [Fact]
        public void Given_ApplicationMediator_When_CommandRequested_Then_ItShouldBeAbleToRun()
        {

            // Arrange
            var command = new TestCommand { Test = "Test of command" };

            // Act
            mediator.Dispatch(command);

            // Assert
            Assert.Equal("Test of command", CommandHandler.TestResult);
        }

        [Fact]
        public async Task Given_ApplicationMediator_When_AsyncCommandRequested_Then_ItShouldBeAbleToRun()
        {

            // Arrange
            var command = new AsyncTestCommand { Test = "Test of asynchronous command" };

            // Act
            await mediator.DispatchAsync(command);

            // Assert
            Assert.Equal("Test of asynchronous command", AsyncCommandHandler.TestResult);
        }

        [Fact]
        public async Task Given_ApplicationMediator_When_AsyncCommandRequested_Then_ItShouldReturnValue()
        {

            // Arrange
            var command = new AsyncTestCommandString { Test = "Test of asynchronous query" };

            // Act
            var result = await mediator.DispatchAsync(command);

            // Assert
            Assert.Equal("Test of asynchronous query", result);
        }

        [Fact]
        public void Given_ApplicationMediator_When_QueryRequested_Then_ItShouldReturnValue()
        {

            // Arrange
            var query = new Query { Test = "Test of query" };

            // Act
            var result = mediator.Dispatch(query);

            // Assert
            Assert.Equal("Test of query", result);
        }

        [Fact]
        public async Task Given_ApplicationMediator_When_AsyncQueryRequested_Then_ItShouldReturnValue()
        {

            // Arrange
            var query = new AsyncQuery { Test = "Test of asynchronous query" };

            // Act
            var result = await mediator.DispatchAsync(query);

            // Assert
            Assert.Equal("Test of asynchronous query", result);
        }


    }
}
