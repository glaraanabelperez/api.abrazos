using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class CouplesEvent_DateDto 
    {
        public int CouplesEventId { get; set; }
        public int HostUserId_FK { get; set; }
        public int InvitedUserId_FK { get; set; }
        public int EventId_FK { get; set; }
        public bool CouplesEventApproved { get; set; }
        public int RequestAccepted { get; set; }

        public EventDto Evento { get; set; } = new EventDto();
        public UserDto HostUser { get; set; } = new UserDto();
        public UserDto InvitedUser { get; set; } = new UserDto();


    }
}