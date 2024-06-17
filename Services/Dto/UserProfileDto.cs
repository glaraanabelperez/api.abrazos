using Models;

namespace ServicesQueries.Dto

{
    public class UserProfileDto 
    {

        public int UserId { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? AvatarImage { get; set; }
        public bool UserState { get; set; }
        public List<ImageDto>? Images { get; set; } = new List<ImageDto>();
        public List<ProfileDancerDto>? ProfileDancer { get; set; } = new List<ProfileDancerDto>();
        public List<UserLanguageDto>? Userlanguages { get; set; } = new List<UserLanguageDto>();


    }
}