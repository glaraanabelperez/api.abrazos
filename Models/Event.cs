using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Event 
    {
        public int EventId { get; set; }
        public int UserIdCreator { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int AddressId { get; set; }
        public string? Image { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateFinish { get; set; }
        public int EventStateId { get; set; }
        public int TypeEventId { get; set; }

        public int? CycleId { get; set; }
        public bool Couple { get; set; }
        public int? Cupo { get; set; }
        public int? RolId { get; set; }
        public int? LevelId { get; set; }


        public DanceLevel? Level { get; set; }
        public DanceRol? Rol { get; set; }
        public Address? Address { get; set; }
        public EventState? EventState { get; set; }
        public TypeEvent? TypeEvent { get; set; }
        public User? UserCreator { get; set; }
        public Cycle? Cycle { get; set; }

        public ICollection<CouplesEventDate>? CouplesEvents { get; set; } = new List<CouplesEventDate>();

        





    }
}