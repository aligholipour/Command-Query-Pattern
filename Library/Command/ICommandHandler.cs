namespace Library.Command
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}
