using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Models
{
    public class User 
    {
       
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string UserIdFirebase { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string? Celphone { get; set; }
        public string? AvatarImage { get; set; }
        public string? Description { get; set; }
        public double? Height { get; set; }
        public bool UserState { get; set; }
        public ICollection<Address>? Address { get; set; } = new List<Address>();
        public ICollection<Image>? Images { get; set; } = new List<Image>();
        public ICollection<UserPermission>? UserPermissions { get; set; } = new List<UserPermission>();
        public ICollection<ProfileDancer>? ProfileDancer { get; set; } = new List<ProfileDancer>();
        public ICollection<CouplesEventDate>? CouplesEventsUserHost { get; set; } = new List<CouplesEventDate>();
        public ICollection<CouplesEventDate>? CouplesEventsUserInivted { get; set; } = new List<CouplesEventDate>();
        public ICollection<TypeEventUser>? TypeEventsUsers { get; set; } = new List<TypeEventUser>();

        public ICollection<Event>? EventsCreated = new List<Event>();
        public ICollection<UserLanguage>? Userlanguages { get; set; } = new List<UserLanguage>();



    }
}