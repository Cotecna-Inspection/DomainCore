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
                .AddHandler<Command, CommandHandler>()
                .AddAsyncHandler<AsyncCommand, AsyncCommandHandler>()
                .AddHandler<Query, QueryHandler, string>()
                .AddAsyncHandler<AsyncQuery, AsyncQueryHandler, string>();

            var serviceProvider = services.BuildServiceProvider();

            mediator = serviceProvider.GetService<IApplicationMediator>();
        }


        [Fact]
        public void Given_ApplicationMediator_When_CommandRequested_Then_ItShouldBeAbleToRun()
        {

            // Arrange
            var command = new Command { Test = "Test of command" };

            // Act
            mediator.Dispatch(command);

            // Assert
            Assert.Equal("Test of command", CommandHandler.TestResult);
        }

        [Fact]
        public async Task Given_ApplicationMediator_When_AsyncCommandRequested_Then_ItShouldBeAbleToRun()
        {

            // Arrange
            var command = new AsyncCommand { Test = "Test of asynchronous command" };

            // Act
            await mediator.DispatchAsync(command);

            // Assert
            Assert.Equal("Test of asynchronous command", AsyncCommandHandler.TestResult);
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
