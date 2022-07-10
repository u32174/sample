using CommandsApi.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandsApi.Services
{
    public interface ICommandService
    {
        Task AddCommandAsync(Command command);
        Task DeleteCommandAsync(Guid commandId);
        Task<IList<Command>> GetAllCommandsAsync();
        Task<Command> GetCommandAsync(Guid commandId);
    }
}
