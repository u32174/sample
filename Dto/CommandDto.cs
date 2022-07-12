using CommandsApi.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CommandsApi.Dto
{
    public class CommandDto
    {
        public Guid Id { get; set; }

        [MaxLength(128)]
        [Required]
        public string Key { get; set; }

        [MaxLength(2048)]
        [Required]
        public string Description { get; set; }

        public CommandDto() { }

        public CommandDto(Command command)
        {
            Id = command.Id;
            Key = command.Key;
            Description = command.Description;
        }

        public Command ConvertToCommand()
        {
            return new Command()
            {
                Id = Id,
                Key = Key,
                Description = Description
            };
        }

        public override string ToString()
        {
            return $"{nameof(Key)}: {Key}, {nameof(Description)}: {Description}";
        }
    }
}
