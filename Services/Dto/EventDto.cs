using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class EventDto 
    {
        public int EventId { get; set; }
        public int UserIdCreator_FK { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int AddressId_fk { get; set; }
        public string? Image { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateFinish { get; set; }
        public int EventStateId_fk { get; set; }
        public int TypeEventId_fk { get; set; }

        public ICollection<WaitListDto> WaitLists { get; set; } = new List<WaitListDto>();

        public ICollection<CouplesEvent_DateDto> CouplesEvents { get; set; } = new List<CouplesEvent_DateDto>();

        //public ICollection<TypeEvent_User> TypeEvent_User = new List<TypeEvent_User>();

        public UserDto UserCreator { get; set; } = new UserDto();

        public AddressDto Address { get; set; } = new AddressDto();

    }
}