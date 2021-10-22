﻿using System;
using System.Threading.Tasks;

namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Defines a mediator to encapsulate command and querys.
    /// Represents <see cref="IApplicationMediator"/> Injectable Service Interface
    /// </summary>
    public interface IApplicationMediator
    {
        /// <summary>
        /// Manage command objects
        /// </summary>
        /// <typeparam name="Command"> <see cref="Command"/></typeparam>
        /// <param name="command">Command object to be dispatched</param>
        void Dispatch(Command command);

        /// <summary>
        /// Manage command objects asynchronously
        /// </summary>
        /// <typeparam name="Command"> <see cref="Command"/></typeparam>
        /// <param name="command">Command object to be dispatched</param>
        Task DispatchAsync(Command command);

        /// <summary>
        /// Manage query objects
        /// </summary>
        /// <typeparam name="Query"> <see cref="Query"/></typeparam>
        /// <param name="query">Query object to be dispatched</param>
        /// <returns>Result object</returns>
        T Dispatch<T>(Query<T> query);

        /// <summary>
        /// Manage query objects asynchronously
        /// </summary>
        /// <typeparam name="Query"> <see cref="Query"/></typeparam>
        /// <param name="query">Query object to be dispatched</param>
        /// <returns>Result object</returns>
        Task<T> DispatchAsync<T>(Query<T> query);
    }



    /// <summary>
    /// Defines a instance of IApplicationMediator <see cref="IApplicationMediator"/> 
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


        public void Dispatch(Command command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            handler.Handle((dynamic)command);
        }

        public async Task DispatchAsync(Command command)
        {
            Type type = typeof(IAsyncCommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            await handler.HandleAsync((dynamic)command);
        }

        public T Dispatch<T>(Query<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }

        public async Task<T> DispatchAsync<T>(Query<T> query)
        {
            Type type = typeof(IAsyncQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = await handler.HandleAsync((dynamic)query);

            return result;
        }

    }
}