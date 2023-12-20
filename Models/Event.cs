using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Event 
    {
        public int EventId { get; set; }
        public int UserIdCreator_FK { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AddressId_fk { get; set; }
        public string? Image { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateFinish { get; set; }
        public int EventStateId_fk { get; set; }
        public int TypeEventId_fk { get; set; }
        public EventState EventState_ { get; set; }
        public TypeEvent TypeEvent_ { get; set; }
        public User UserCreator { get; set; }
        public Address Address { get; set; }
        public ICollection<WaitList> WaitLists { get; set; } = new List<WaitList>();
        public ICollection<CouplesEvent_Date> CouplesEvents { get; set; } = new List<CouplesEvent_Date>();




    }
}