using System.Threading.Tasks;

namespace Cotecna.Domain.Core.Test
{
    public class Query : IQuery<string>
    {
        public string Test { get; set; }
    }

    public class QueryHandler : IQueryHandler<Query, string>
    {
        public string Handle(Query query)
        {
            return query.Test;
        }
    }

    public class AsyncQuery : IQuery<string>
    {
        public string Test { get; set; }
    }

    public class AsyncQueryHandler : IAsyncQueryHandler<AsyncQuery, string>
    {
        public async Task<string> HandleAsync(AsyncQuery query)
        {
            await Task.Delay(2);
            return query.Test;
        }
    }

}
