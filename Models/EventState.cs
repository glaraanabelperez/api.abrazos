using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EventState
    {
        public int EventStateId { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}