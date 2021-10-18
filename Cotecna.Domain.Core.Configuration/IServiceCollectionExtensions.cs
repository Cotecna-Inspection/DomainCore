using Microsoft.Extensions.DependencyInjection;

namespace Cotecna.Domain.Core
{
    public static class IServiceCollectionExtensions
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
            where TCommand : ICommand
        {
            services.AddTransient<ICommandHandler<TCommand>, THandler>();

            return services;
        }

        /// <summary>
        /// Add a new Query Handler with the specified Query to the current DI container, easing configuration and promoting fluent syntax
        /// </summary>
        /// <param name="services">Services DIC</param>
        /// <returns>Same Services DIC</returns>
        public static IServiceCollection AddHandler<TQuery, THandler, TResult>(this IServiceCollection services)
            where THandler : class, IQueryHandler<TQuery, TResult>
            where TQuery : IQuery<TResult>
        {
            services.AddTransient<IQueryHandler<TQuery, TResult>, THandler>();

            return services;
        }

    }
}
