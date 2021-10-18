using System;

using Cotecna.Domain.Core.Interfaces;

namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Defines a instance of <see cref="ApplicationMediator"/>. Implements <see cref="IApplicationMediator"/> 
    /// </summary>
    public sealed class ApplicationMediator : IApplicationMediator
    {

        private readonly IServiceProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="IApplicationMediator"/> class.
        /// </summary>
        /// <param name="provider">The single instance of <see cref="IServiceProvider"/></param>
        public ApplicationMediator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public bool Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            bool flag = handler.Handle((dynamic)command);

            return flag;
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }
    }
}