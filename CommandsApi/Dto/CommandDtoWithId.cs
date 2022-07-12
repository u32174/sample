using CommandsApi.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CommandsApi.Dto
{
    public class CommandDtoWithId : CommandDto
    {
        [Required]
        public Guid Id { get; set; }

        public CommandDtoWithId(Command command): base(command)
        {
            Id = command.Id;
        }

        public override Command ConvertToCommand()
        {
            Command result = base.ConvertToCommand();
            result.Id = Id;
            return result;
        }
    }
}
