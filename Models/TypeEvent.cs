using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypeEvent
    {
        public int TypeEventId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<TypeEvent_User> TypeEventsUsers { get; set; } = new List<TypeEvent_User>();
        public ICollection<Event> events { get; set; } = new List<Event>();

    }
}