using CommandsApi.Data.Entities;
using CommandsApi.Dto;
using CommandsApi.Repositories;
using CommandsApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CommandsApi.Controllers
{
    [ApiController]
    [Route("command")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;
        private readonly ICommandService _commandService;

        public CommandController(ILogger<CommandController> logger,
            ICommandService commandService)
        {
            _logger = logger;
            _commandService = commandService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCommand(CommandDto commandDto)
        {
            try
            {
                Command command = commandDto.ConvertToCommand();
                await _commandService.AddCommandAsync(command);
                return CreatedAtAction(
                    nameof(GetCommand),
                    new { id = command.Id },
                    new CommandDtoWithId(command)
                    );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add Command {commandDto}", commandDto);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommand(Guid id)
        {
            try
            {
                Command command = await _commandService.GetCommandAsync(id);
                if (command == null)
                {
                    return NotFound();
                }

                return Ok(new CommandDtoWithId(command));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured during attempt to get Command by {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommand(Guid id)
        {
            try
            {
                await _commandService.DeleteCommandAsync(id);
                return Ok();
            }
            catch (RecordNotFoundException ex)
            {
                _logger.LogError(ex, "Failed to retrieve Command {id} for deletion", id);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured during attempt to delete Command by {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommands()
        {
            try
            {
                return Ok(await _commandService.GetAllCommandsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured during attempt to retrieve all Commands");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
