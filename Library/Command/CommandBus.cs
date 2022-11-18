namespace Library.Command
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceProvider _provider;
        public CommandBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task Dispatch<T>(T command)
        {
            var service = _provider.GetService(typeof(ICommandHandler<T>)) as ICommandHandler<T>;
            await service.Handle(command);
        }
    }
}
