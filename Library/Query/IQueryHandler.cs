namespace Library.Query
{
    public interface IQueryHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest command);
    }
}
