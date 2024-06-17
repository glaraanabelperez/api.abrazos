using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class DanceLevelUpdateCommand
    {
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
        public int ProfileLevelId { get; set; }
        [StringLength(255, MinimumLength = 8)]
        public string? Name { get; set; } = null!;
    }
}
