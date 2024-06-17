

using Models;

namespace ServicesQueries.Dto
{
    public class EventDto 
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

        public bool? Couple { get; set; }
        public int? Cupo { get; set; }
        public int? RolId { get; set; }
        public int? LevelId { get; set; }


        public DanceLevelDto? Level { get; set; }
        public DanceRolDto? Rol { get; set; }
        public AddressDto? Address { get; set; }
        public EventStateDto? EventState { get; set; }
        public TypeEventDto? TypeEvent { get; set; }
        //public UserDto? UserCreator { get; set; }
        public CycleDto? Cycle { get; set; }

        public ICollection<CouplesEventDateDto>? CouplesEvents { get; set; } = new List<CouplesEventDateDto>();



    }
}