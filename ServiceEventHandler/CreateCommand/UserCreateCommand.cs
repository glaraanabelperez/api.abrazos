using System.ComponentModel.DataAnnotations;

namespace Abrazos.ServiceEventHandler.Commands
{
    public class UserCreateCommand
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Pass { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        public int? Age { get; set; }
        [MaxLength(100)]
        public string? Celphone { get; set; }
        [MaxLength(100)]
        public string? AvatarImage { get; set; }
        public int? ProfileDancer_FK { get; set; }
        public byte UserState { get; set; }

    }
}
