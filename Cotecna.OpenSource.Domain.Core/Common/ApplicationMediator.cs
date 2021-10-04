using System;

namespace Cotecna.OpenSource.Domain.Core.Common
{
    public interface ApplicationMediator
    {
        public interface IApplicationMediator
        {
            bool Dispatch(ICommand command);

            T Dispatch<T>(IQuery<T> query);
        }

        public sealed class ApplicationMediator : IApplicationMediator
        {
            private readonly IServiceProvider _provider;

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
}