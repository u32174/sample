using CommandsApi.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CommandsApi.Dto
{
    public class CommandDto
    {
        [MaxLength(128)]
        [Required]
        public string Key { get; set; }

        [MaxLength(2048)]
        [Required]
        public string Description { get; set; }

        public CommandDto() { }

        public CommandDto(Command command)
        {
            Key = command.Key;
            Description = command.Description;
        }

        public virtual Command ConvertToCommand()
        {
            return new Command()
            {
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
