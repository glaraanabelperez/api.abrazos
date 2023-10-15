using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Users 
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string? Celphone { get; set; }
        public string? AvatarImage { get; set; }
        public string? ProfileDancer_FK { get; set; }
        public byte UserState { get; set; }
    }
}