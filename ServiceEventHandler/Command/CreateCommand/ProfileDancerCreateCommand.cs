

using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class ProfileDancerCreateCommand
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
        public int DanceLevel_FK { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
        public int DanceRol_FK { get; set; }
        public double Height { get; set; }
    }
}