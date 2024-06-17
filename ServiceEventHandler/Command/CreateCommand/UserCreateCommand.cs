using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class UserCreateCommand
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(250)]
        public string LastName { get; set; } 
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; } 
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string UserIdFirebase { get; set; } = null!;
        [Required]
        public int Age { get; set; }
        [MaxLength(250)]
        public string? Celphone { get; set; }
        [MaxLength(250)]
        public string? AvatarImage { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
        public double? Height { get; set; }
        public List<int>? TypeEvents { get; set; } = null;

        public List<AddressCreateCommand>? Addresses { get; set; } = null;

    }
}
