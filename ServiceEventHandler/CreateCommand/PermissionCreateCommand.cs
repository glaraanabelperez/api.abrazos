using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.CreateCommand
{
    public class PermissionCreateCommand
    {
        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Name { get; set; } = string.Empty;
    }
}