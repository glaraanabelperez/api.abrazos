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
        public string? ProfileDancer_FK { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte UserState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Event> Events = new List<Event>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Address> Address = new List<Address>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Image> Images = new List<Image>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<UserPermission> UserPermissions = new List<UserPermission>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<ProfileDancer> ProfileDancers = new List<ProfileDancer>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CouplesEvent_Date> CouplesEvents = new List<CouplesEvent_Date>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<TypeEvent_User> TypeEventsUsers = new List<TypeEvent_User>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<WaitList> WaitLists = new List<WaitList>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Event> EventsCreated = new List<Event>();


    }
}