using System;
using System.Linq;
using CommandsApi.Data;
using CommandsApi.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CommandsApi.Data.Entities;

namespace CommandsApiTests
{
    // Integration tests to verify repository operations
    [TestClass]
    public class CommandRepositoryTests
    {
        const string CONNECTION_STRING = "Server=localhost;Database=testDb;Uid=commandsApiUser;Pwd=q!123456";

        [TestMethod]
        public async Task TestRepositoryOperations()
        {
            using var context = new CommandsDbContext(CONNECTION_STRING);

            var repository = new CommandRepository(context);

            Command newCommand = new()
            {
                Id = Guid.NewGuid(),
                Key = "Test Key",
                Description = "Fake command for testing"
            };

            await repository.AddCommandAsync(newCommand);
            await repository.SaveChangesAsync();

            List<Command> commands = await repository.GetCommands().ToListAsync();

            int retrievedCommandCount = commands.Count;
            Command retrievedCommand = commands.SingleOrDefault(c => c.Id == newCommand.Id);

            Assert.IsNotNull(retrievedCommand);
            Assert.AreEqual(newCommand.Description, retrievedCommand.Description);
            Assert.AreEqual(newCommand.Key, retrievedCommand.Key);

            await repository.DeleteCommandAsync(newCommand.Id);
            await repository.SaveChangesAsync();

            commands = await repository.GetCommands().ToListAsync();

            Assert.AreEqual(retrievedCommandCount - 1, commands.Count);
        }

        [TestMethod]
        public async Task TestGetCommand()
        {
            using var context = new CommandsDbContext(CONNECTION_STRING);

            var repository = new CommandRepository(context);

            Command newCommand = new()
            {
                Id = Guid.NewGuid(),
                Key = "Test Key",
                Description = "Fake command for testing"
            };

            await repository.AddCommandAsync(newCommand);
            await repository.SaveChangesAsync();

            Command retrievedCommand = await repository.GetCommandAsync(newCommand.Id);

            Assert.AreEqual(newCommand.Id, retrievedCommand.Id);
            Assert.AreEqual(newCommand.Description, retrievedCommand.Description);
            Assert.AreEqual(newCommand.Key, retrievedCommand.Key);

            await repository.DeleteCommandAsync(newCommand.Id);
            await repository.SaveChangesAsync();
        }
    }
}

