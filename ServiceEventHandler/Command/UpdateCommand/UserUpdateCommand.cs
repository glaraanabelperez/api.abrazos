using Models;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class UserUpdateCommand
    {
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than zero.")]
        public int userId { get; set; }
        [MaxLength(250)]
        public string? Name { get; set; }
        [MaxLength(250)]
        public string? LastName { get; set; }
        [MaxLength(250)]
        public string? UserName { get; set; }
        [MaxLength(50)]
        public string? Pass { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        public int? Age { get; set; }
        [MaxLength(250)]
        public string? Celphone { get; set; }
        [MaxLength(250)]
        public string? AvatarImage { get; set; }
        //ProfileDancer Update
        //public ProfileDancerUpdateCommand? ProfileDancerUpdateCommand { get; set; } 


    }
}
