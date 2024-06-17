using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class UserUpdateCommand
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
        public int userId { get; set; }

        [MaxLength(250)]
        public string? Name { get; set; } = null!;
        [MaxLength(250)]
        public string? LastName { get; set; }
        [MaxLength(250)]
        public string? UserName { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? UserIdFirebase { get; set; }
        public int? Age { get; set; }
        [MaxLength(250)]
        public string? Celphone { get; set; }
        [MaxLength(250)]
        public string? AvatarImage { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
        public double? Height { get; set; }
        public List<int>? TypeEvents { get; set; }

        public List<AddressCreateCommand>? Addresses { get; set; }


    }
}
