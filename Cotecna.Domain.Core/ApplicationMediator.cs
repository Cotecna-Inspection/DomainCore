using System;

namespace Cotecna.Domain.Core
{
    /// <summary>
    /// Defines a mediator to encapsulate command and querys.
    /// Represents <see cref="IApplicationMediator"/> Injectable Service Interface
    /// </summary>
    public interface IApplicationMediator
    {

        /// <summary>
        /// Manage comand objects
        /// </summary>
        /// <typeparam name="ICommand"> <see cref="ICommand"/></typeparam>
        /// <param name="command">Command object to be dispatched</param>
        /// <returns>Returns boolean if Command was correctly dispatched</returns>
        bool Dispatch(ICommand command);

        /// <summary>
        /// Manage comand objects
        /// </summary>
        /// <typeparam name="IQuery"> <see cref="IQuery"/></typeparam>
        /// <param name="query">Query object to be dispatched</param>
        /// <returns>Result object</returns>
        T Dispatch<T>(IQuery<T> query);
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