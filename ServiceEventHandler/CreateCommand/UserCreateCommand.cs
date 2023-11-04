using ServiceEventHandler.CreateCommand;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.ServiceEventHandler.Commands
{
    public class UserCreateCommand
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Pass { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        public int? Age { get; set; }
        [MaxLength(250)]
        public string? Celphone { get; set; }
        [MaxLength(250)]
        public string? AvatarImage { get; set; }

        public ProfileDancerCreateCommand? ProfileDancerCreateCommand { get; set; } = new ProfileDancerCreateCommand();

    }
}
