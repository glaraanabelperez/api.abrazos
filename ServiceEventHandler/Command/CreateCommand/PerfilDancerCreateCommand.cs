using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class PerfilDancerCreateCommand
    {
        [Required]
        public int DanceLevel_FK { get; set; }
        [Required]
        public int DanceRol_FK { get; set; }
        public decimal Height { get; set; }

        public DanceLevelCreateCommand DanceLevel { get; set; } = new DanceLevelCreateCommand();
        public DanceRolCreateCommand DanceRol { get; set; } = new DanceRolCreateCommand();


    }

}
