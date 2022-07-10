using Microsoft.Extensions.DependencyInjection;

namespace CommandsApi.Data
{
    public static class CommandsDbContextExtensions
    {
        public static void AddCommandsDbMySqlContext(this IServiceCollection services, string connectionString)
        {
            services.Add(new ServiceDescriptor(typeof(CommandsDbContext), new CommandsDbContext(connectionString)));
        }
    }
}
