using CommandsApi.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsApi.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        CommandsDbContext _dbContext;

        public CommandRepository(CommandsDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            _dbContext = dbContext;
        }

        public async Task AddCommandAsync(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await _dbContext.Commands.AddAsync(command);
        }

        public async Task DeleteCommandAsync(Guid commandId)
        {
            var command = await _dbContext.Commands.FindAsync(commandId);
            if (command == null)
            {
                throw new ArgumentException($"Failed to find command to delete. CommandId {commandId}");
            }
            _dbContext.Commands.Remove(command);
        }

        public IQueryable<Command> GetCommands()
        {
            return _dbContext.Commands;
        }

        public async Task<Command> GetCommandAsync(Guid commandId)
        {
            return await _dbContext.Commands.FindAsync(commandId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
