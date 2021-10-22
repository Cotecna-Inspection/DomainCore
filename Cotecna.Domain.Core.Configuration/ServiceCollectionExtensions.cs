using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Cotecna.Domain.Core
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Add ApplicationMediator to the current DI container
        /// </summary>
        /// <param name="services">Services DIC</param>
        /// <returns>Same Services DIC</returns>
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddTransient<IApplicationMediator, ApplicationMediator>();

            return services;
        }

        /// <summary>
        /// Add a new Command Handler with the specified Command to the current DI container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services DIC</param>
        /// <returns>Same Services DIC</returns>
        public static IServiceCollection AddHandler<TCommand, THandler>(this IServiceCollection services)
            where THandler : class, ICommandHandler<TCommand>
            where TCommand : Command
        {
            services.AddTransient<ICommandHandler<TCommand>, THandler>();

            return services;
        }

        /// <summary>
        /// Add a new Asynchronous Command Handler with the specified Command to the current DI container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services DIC</param>
        /// <returns>Same Services DIC</returns>
        public static IServiceCollection AddAsyncHandler<TCommand, THandler>(this IServiceCollection services)
            where THandler : class, IAsyncCommandHandler<TCommand>
            where TCommand : Command
        {
            services.AddTransient<IAsyncCommandHandler<TCommand>, THandler>();

            return services;
        }

        /// <summary>
        /// Add a new Query Handler with the specified Query to the current DI container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services DIC</param>
        /// <returns>Same Services DIC</returns>
        public static IServiceCollection AddHandler<TQuery, THandler, TResult>(this IServiceCollection services)
            where THandler : class, IQueryHandler<TQuery, TResult>
            where TQuery : Query<TResult>
        {
            services.AddTransient<IQueryHandler<TQuery, TResult>, THandler>();

            return services;
        }

        /// <summary>
        /// Add a new Asynchronous Query Handler with the specified Query to the current DI container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services DIC</param>
        /// <returns>Same Services DIC</returns>
        public static IServiceCollection AddAsyncHandler<TQuery, THandler, TResult>(this IServiceCollection services)
            where THandler : class, IAsyncQueryHandler<TQuery, TResult>
            where TQuery : Query<TResult>
        {
            services.AddTransient<IAsyncQueryHandler<TQuery, TResult>, THandler>();

            return services;
        }

    }
}
