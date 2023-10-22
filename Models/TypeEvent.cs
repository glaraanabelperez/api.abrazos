using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypeEvent
    {
        public int TypeEventId { get; set; }
        public int UserId_FK { get; set; }

        public ICollection<TypeEvent_User> TypeEventsUsers = new List<TypeEvent_User>();

        public ICollection<Event> Events = new List<Event>();

    }
}