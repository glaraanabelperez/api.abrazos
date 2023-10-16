using System.ComponentModel.DataAnnotations;

namespace Abrazos.ServiceEventHandler.Commands
{
    public class UserAddCommand
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Pass { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }
        public int? Age { get; set; }
        [MaxLength(100)]
        public string? Celphone { get; set; }
        public string? AvatarImage { get; set; }
        public string? ProfileDancer_FK { get; set; }
        public byte UserState { get; set; }
    }
}
