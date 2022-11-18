namespace Library.Command
{
    public interface ICommandBus
    {
        Task Dispatch<T>(T command);
    }
}
