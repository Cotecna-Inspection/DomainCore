using System;
using System.Threading.Tasks;

namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Defines a mediator to encapsulate <see cref="Command"/> and <see cref="Query{T}"/> objects.
    /// Represents a <see cref="IApplicationMediator"/> Injectable Service Interface
    /// </summary>
    public interface IApplicationMediator
    {

        /// <summary>
        /// Dispatches <see cref="Command"/> objects Synchronously
        /// </summary>
        /// <param name="command"><see cref="Command"/> object to be dispatched</param>
        void Dispatch(Command command);

        /// <summary>
        /// Dispatches <see cref="Command"/> objects Asynchronously
        /// </summary>
        /// <param name="command"><see cref="Command"/> object to be dispatched</param>
        Task DispatchAsync(Command command);

        /// <summary>
        /// Dispatches <see cref="Command"/> objects Synchronously
        /// </summary>
        /// <param name="command"><see cref="Command"/> object to be dispatched</param>
        /// <returns>Result <see cref="Task{TResult}"/> object</returns>
        Task<TResult> DispatchAsync<TResult>(Command<TResult> command);

        /// <summary>
        /// Dispatches <see cref="Query{TResult}"/> objects Synchronously
        /// </summary>
        /// <param name="query"> <see cref="Query{T}"/> object to be dispatched</param>
        /// <returns>Result <see cref="{TResult}"/> object</returns>
        TResult Dispatch<TResult>(Query<TResult> query);

        /// <summary>
        /// Dispatches <see cref="Query{TResult}"/> objects Asynchronously
        /// </summary>
        /// <param name="query"> <see cref="Query{TResult}"/> object to be dispatched</param>
        /// <returns>Result <see cref="Task{TResult}"/> object</returns>
        Task<TResult> DispatchAsync<TResult>(Query<TResult> query);
        
    }


    /// <summary>
    /// Defines an instance of <see cref="ApplicationMediator"/>. Implements <see cref="IApplicationMediator"/>
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

        public async Task<TResult> DispatchAsync<TResult>(Command<TResult> command)
        {
            Type type = typeof(IAsyncCommandHandler<,>);
            Type[] typeArgs = { command.GetType(), typeof(TResult) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            TResult result = await handler.HandleAsync((dynamic)command);

            return result;
        }

        public TResult Dispatch<TResult>(Query<TResult> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(TResult) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            TResult result = handler.Handle((dynamic)query);

            return result;
        }

        public async Task<TResult> DispatchAsync<TResult>(Query<TResult> query)
        {
            Type type = typeof(IAsyncQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(TResult) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            TResult result = await handler.HandleAsync((dynamic)query);

            return result;
        }
        
    }
}