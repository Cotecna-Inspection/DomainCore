namespace Cotecna.OpenSource.Domain.Core.Common
{
    public interface ICommand { }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        bool Handle(TCommand command);
    }
}