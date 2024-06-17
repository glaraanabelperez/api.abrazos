using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServicesQueries.Dto
{
    public class CouplesEventDateDto 
    {
        public int CouplesEventId { get; set; }
        public int HostUserId { get; set; }
        public int InvitedUserId { get; set; }
        public int EventId { get; set; }
        public bool CouplesEventApproved { get; set; }
        public int RequestAccepted { get; set; }
        public int RequestRejected{ get; set; }

        public EventDto Evento { get; set; } = new EventDto();
        //public UserDto HostUser { get; set; } = new UserDto();
        //public UserDto InvitedUser { get; set; } = new UserDto();



    }
}