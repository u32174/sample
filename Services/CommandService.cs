using CommandsApi.Data;
using CommandsApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommandsApi.Services
{
    public class CommandService : ICommandService
    {
        private ICommandRepository _repository;

        public CommandService(ICommandRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            _repository = repository;
        }

        public async Task AddCommandAsync(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await _repository.AddCommandAsync(command);
            await _repository.SaveChangesAsync();

            if (command.Id == Guid.Empty)
            {
                throw new Exception("Failed to save command to db or update newly created command");
            }
        }

        public async Task DeleteCommandAsync(Guid commandId)
        {
            if (commandId == Guid.Empty)
            {
                throw new ArgumentException("Empty commandId");
            }

            await _repository.DeleteCommandAsync(commandId);
            await _repository.SaveChangesAsync();
        }

        public async Task<IList<Command>> GetAllCommandsAsync()
        {
            return await _repository.GetCommands().ToListAsync();
        }

        public async Task<Command> GetCommandAsync(Guid commandId)
        {
            if (commandId == Guid.Empty)
            {
                throw new ArgumentException("Empty commandId");
            }

            return await _repository.GetCommandAsync(commandId);
        }
    }
}
