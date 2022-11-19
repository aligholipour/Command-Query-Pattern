using Microsoft.Extensions.DependencyInjection;

namespace Library.Query
{
    public class QueryBus : IQueryBus
    {
        private readonly IServiceProvider _provider;
        public QueryBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResponse> Dispatch<TRequest, TResponse>(TRequest query)
        {
            var service = _provider.GetRequiredService(typeof(IQueryHandler<TRequest, TResponse>)) as IQueryHandler<TRequest, TResponse>;
            return await service.Handle(query);
        }
    }
}
