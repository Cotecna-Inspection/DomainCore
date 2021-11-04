using System.Threading.Tasks;

namespace Cotecna.Domain.Core.Test
{
    public class TestCommand : Command
    {
        public string Test { get; set; }
    }

    public class CommandHandler : ICommandHandler<TestCommand>
    {
        public void Handle(TestCommand command)
        {
            TestResult = command.Test;
        }

        public static string TestResult { get; set; }
    }

    public class AsyncCommandHandler : IAsyncCommandHandler<AsyncTestCommand>
    {
        public async Task HandleAsync(AsyncTestCommand command)
        {
            await Task.Delay(2);
            TestResult = command.Test;
        }        

        public static string TestResult { get; set; }
    }

    public class AsyncCommandHandlerString : IAsyncCommandHandler<AsyncTestCommandString,string>
    {       

        public static string TestResult { get; set; }

        public async Task<string> HandleAsync(AsyncTestCommandString command)
        {
            await Task.Delay(2);
            TestResult = command.Test;
            return TestResult;
        }
    }

    public class AsyncTestCommand : Command
    {
        public string Test { get; set; }
    }

    public class AsyncTestCommandString : Command<string>
    {
        public string Test { get; set; }
    }

}
