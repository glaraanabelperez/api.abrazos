using Models;
using ServiceEventHandler.CreateCommand;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.ServiceEventHandler.Commands
{
    public class DanceRolCreateCommand
    {

        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Name { get; set; } = null!;
    }
}
