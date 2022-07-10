using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandsApi.Data
{
    public class Command
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
    }
}
