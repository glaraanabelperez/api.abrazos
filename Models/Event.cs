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

        public ICollection<WaitList> WaitLists = new List<WaitList>();

        public ICollection<CouplesEvent_Date> CouplesEvents = new List<CouplesEvent_Date>();

        //public ICollection<TypeEvent_User> TypeEvent_User = new List<TypeEvent_User>();

        public User UserCreator = new User();

        public Address Address = new Address();

    }
}