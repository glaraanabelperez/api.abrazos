
using Models;

namespace Abrazos.Services.Dto
{
    public class UserDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Pass { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Celphone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? AvatarImage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ProfileDancerId_FK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool UserState { get; set; }


        ///// <summary>
        ///// 
        ///// </summary>
        //public ICollection<AddressDto>? Address { get; set; } = new List<AddressDto>();
        ///// <summary>
        ///// 
        ///// </summary>
        //public ICollection<ImageDto>? Images { get; set; } = new List<ImageDto>();

        ///// <summary>
        ///// 
        ///// </summary>
        //public ICollection<UserPermissionDto>? UserPermissions { get; set; } = new List<UserPermissionDto>();
        ///// <summary>
        ///// 
        ///// </summary>
        //public ICollection<Permission>? Permissions { get; set; } = new List<Permission>();

        /// <summary>
        /// 
        /// </summary>
        public ProfileDancerDto? ProfileDancer { get; set; } 
        ///// <summary>
        ///// 
        ///// </summary>
        //public ICollection<CouplesEvent_DateDto>? CouplesEventsHost { get; set; } = new List<CouplesEvent_DateDto>();
        ///// <summary>
        ///// 
        ///// </summary>
        //public ICollection<CouplesEvent_DateDto>? CouplesEventsInvited { get; set; } = new List<CouplesEvent_DateDto>();
        ///// <summary>
        ///// 
        ///// </summary>
        //public ICollection<TypeEvent_UserDto>? TypeEventsUsers { get; set; } = new List<TypeEvent_UserDto>();
        ///// <summary>
        ///// 
        ///// </summary>
        //public ICollection<WaitListDto>? WaitLists { get; set; } = new List<WaitListDto>();
        ///// <summary>
        ///// 
        ///// </summary>{ get; set; }
        //public ICollection<EventDto>? EventsCreated = new List<EventDto>();





    }
}