using Models;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.ServiceEventHandler.Commands
{
    public class PerfilDancerCreateCommand
    {
        public decimal Height { get; set; }
        [Required]
        public DanceRolCreateCommand DanceRol { get; set; } = new DanceRolCreateCommand();
        [Required]
        public DanceLevelCreateCommand DanceLevel { get; set; } = new DanceLevelCreateCommand();
    }

}
