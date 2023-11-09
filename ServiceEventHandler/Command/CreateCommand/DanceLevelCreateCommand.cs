using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class DanceLevelCreateCommand
    {
        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Name { get; set; } = null!;
    }
}
