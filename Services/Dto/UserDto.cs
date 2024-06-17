using Models;

namespace ServicesQueries.Dto

{
    public class UserDto 
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? UserIdFirebase { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string? Celphone { get; set; }
        public string? AvatarImage { get; set; }
        public bool UserState { get; set; }

        public string? Description { get; set; }
        public double? Height { get; set; }
        //public ICollection<AddressDto>? Address { get; set; } = new List<AddressDto>();
        public ICollection<ImageDto>? Images { get; set; } = new List<ImageDto>();
        //public ICollection<UserPermissionDto>? UserPermissions { get; set; } = new List<UserPermissionDto>();

        //public ICollection<Permission>? Permissions { get; set; } = new List<Permission>();
        //public ICollection<ProfileDancerDto>? ProfileDancer { get; set; } = new List<ProfileDancerDto>();
        //public ICollection<CouplesEventDateDto>? CouplesEventsUserHost { get; set; } = new List<CouplesEventDateDto>();
        //public ICollection<CouplesEventDateDto>? CouplesEventsUserInivted { get; set; } = new List<CouplesEventDateDto>();

        //public ICollection<TypeEventUserDto>? TypeEventsUsers { get; set; } = new List<TypeEventUserDto>();

        //public ICollection<EventDto>? EventsCreated = new List<EventDto>();
        //public ICollection<UserLanguageDto>? Userlanguages { get; set; } = new List<UserLanguageDto>();


    }
}