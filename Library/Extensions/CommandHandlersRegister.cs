using Microsoft.Extensions.DependencyInjection;

namespace Library.Command
{
    public static class CommandQueryHandlersRegister
    {
        public static IServiceCollection AddCommandQueryHandlers(this IServiceCollection services, Type assemblyType, Type commandQueryHandler)
        {
            var handlers = assemblyType.Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == commandQueryHandler));

            foreach (var handler in handlers)
                services.AddScoped(handler.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == commandQueryHandler), handler);

            return services;
        }
    }
}
