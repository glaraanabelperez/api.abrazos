using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class ProfileDancerUpdateCommand
    {
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
        public int ProfileDanceId { get; set; }
        public int DanceLevel_FK { get; set; }
        public int DanceRol_FK { get; set; }
        public double? Height { get; set; }

    }
}