using System.Threading.Tasks;

namespace Cotecna.Domain.Core.Test
{
    public class Command : ICommand
    {
        public string Test { get; set; }
    }

    public class CommandHandler : ICommandHandler<Command>
    {
        public void Handle(Command command)
        {
            TestResult = command.Test;
        }

        public static string TestResult { get; set; }
    }

    public class AsyncCommandHandler : IAsyncCommandHandler<AsyncCommand>
    {
        public async Task HandleAsync(AsyncCommand command)
        {
            await Task.Delay(2);
            TestResult = command.Test;
        }

        public static string TestResult { get; set; }
    }

    public class AsyncCommand : ICommand
    {
        public string Test { get; set; }
    }

}
