using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Models
{
    public class User 
    {
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
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
        public string Pass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
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


        /// <summary>
        /// 
        /// </summary>
        public ICollection<Address>? Address { get; set; } = new List<Address>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Image>? Images { get; set; } = new List<Image>();

        /// <summary>
        /// 
        /// </summary>
        public ICollection<UserPermission>? UserPermissions { get; set; } = new List<UserPermission>();
        ///// <summary>
        ///// 
        ///// </summary>
        //public ICollection<Permission>? Permissions { get; set; } = new List<Permission>();

        /// <summary>
        /// 
        /// </summary>
        public ProfileDancer? ProfileDancer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CouplesEvent_Date>? CouplesEventsHost { get; set; } = new List<CouplesEvent_Date>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CouplesEvent_Date>? CouplesEventsInvited { get; set; } = new List<CouplesEvent_Date>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<TypeEvent_User>? TypeEventsUsers { get; set; } = new List<TypeEvent_User>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<WaitList>? WaitLists { get; set; } = new List<WaitList>();
        /// <summary>
        /// 
        /// </summary>{ get; set; }
        public ICollection<Event>? EventsCreated = new List<Event>();


    }
}