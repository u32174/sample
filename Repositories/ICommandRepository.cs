using CommandsApi.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsApi.Repositories
{
    public interface ICommandRepository
    {
        Task DeleteCommandAsync(Guid commandId);
        IQueryable<Command> GetCommands();
        Task<Command> GetCommandAsync(Guid commandId);
        Task AddCommandAsync(Command command);
        Task SaveChangesAsync();
    }
}
