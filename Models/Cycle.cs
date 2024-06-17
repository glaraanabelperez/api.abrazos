using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Cycle
    {
        public int CycleId { get; set; }
        public string CycleTitle { get; set; }
        public string Description { get; set; }

        public ICollection<Event>? Events { get; set; } 

    }
}