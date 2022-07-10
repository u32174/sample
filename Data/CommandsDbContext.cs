using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CommandsApi.Data
{
    public class CommandsDbContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }

        private const string CONNECTION_STRING_NAME = "TestDb";

        private readonly IConfiguration _configuration;

        public CommandsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_configuration.GetConnectionString(CONNECTION_STRING_NAME));
        }
    }
}
