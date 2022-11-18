using Microsoft.Extensions.DependencyInjection;

namespace Library.Command
{
    public static class CommandHandlersRegister
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services, Type assemblyType)
        {
            var handlers = assemblyType.Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)));

            foreach (var handler in handlers)
                services.AddScoped(handler.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)), handler);

            return services;
        }
    }
}
