
using Microsoft.Extensions.DependencyInjection;

namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Represents <see cref="IServiceCollectionExtensions"/> defining as a container for Services added through Dependency Injection.
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds ApplicationMediator to the current Dependency Injection container
        /// </summary>
        /// <param name="services">Services Dependency Injection Container</param>
        /// <returns>Same Services Dependency Injection Container</returns>
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddTransient<IApplicationMediator, ApplicationMediator>();

            return services;
        }

        /// <summary>
        /// Adds a new Syncronous Command Handler with the specified Command to the current Dependency Injection Container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services Dependency Injection Container</param>
        /// <returns>Same Services Dependency Injection Container</returns>
        public static IServiceCollection AddCommandHandler<TCommand, THandler>(this IServiceCollection services)
            where THandler : class, ICommandHandler<TCommand>
            where TCommand : Command
        {
            services.AddTransient<ICommandHandler<TCommand>, THandler>();

            return services;
        }

        /// <summary>
        /// Adds a new Asynchronous Command Handler with the specified Command to the current Services Dependency Injection Container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services Dependency Injection Container</param>
        /// <returns>Same Services Dependency Injection Container</returns>
        public static IServiceCollection AddCommandAsyncHandler<TCommand, THandler>(this IServiceCollection services)
            where THandler : class, IAsyncCommandHandler<TCommand>
            where TCommand : Command
        {
            services.AddTransient<IAsyncCommandHandler<TCommand>, THandler>();

            return services;
        }

        /// <summary>
        /// Adds a new Asynchronous Command Handler with the specified Query to the current Services Dependency Injection Container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services Dependency Injection Container</param>
        /// <returns>Same Services Dependency Injection Container</returns>
        public static IServiceCollection AddCommandAsyncHandler<TCommand, THandler, TResult>(this IServiceCollection services)
            where THandler : class, IAsyncCommandHandler<TCommand, TResult>
            where TCommand : Command<TResult>
        {
            services.AddTransient<IAsyncCommandHandler<TCommand, TResult>, THandler>();

            return services;
        }

        /// <summary>
        /// Adds a new Syncronous Query Handler with the specified Query to the current Services Dependency Injection Container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services Dependency Injection Container</param>
        /// <returns>Same Services Dependency Injection Container</returns>
        public static IServiceCollection AddQueryHandler<TQuery, THandler, TResult>(this IServiceCollection services)
            where THandler : class, IQueryHandler<TQuery, TResult>
            where TQuery : Query<TResult>
        {
            services.AddTransient<IQueryHandler<TQuery, TResult>, THandler>();

            return services;
        }

        /// <summary>
        /// Adds a new Asynchronous Query Handler with the specified Query to the current Services Dependency Injection Container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services Dependency Injection Container</param>
        /// <returns>Same Services Dependency Injection Container</returns>
        public static IServiceCollection AddQueryAsyncHandler<TQuery, THandler, TResult>(this IServiceCollection services)
            where THandler : class, IAsyncQueryHandler<TQuery, TResult>
            where TQuery : Query<TResult>
        {
            services.AddTransient<IAsyncQueryHandler<TQuery, TResult>, THandler>();

            return services;
        }        

    }
}
