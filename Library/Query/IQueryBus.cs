namespace Library.Query
{
    public interface IQueryBus
    {
        Task<TResponse> Dispatch<TRequest, TResponse>(TRequest command);
    }
}
