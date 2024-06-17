using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class ProfileDancerUpdateCommand
    {
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
        public int ProfileDancerId { get; set; }
        public int? DanceLevelId { get; set; }
        public int? DanceRolId { get; set; }
    }
}