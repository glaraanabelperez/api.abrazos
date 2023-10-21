using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CouplesEvent_Date 
    {
        public int CouplesEventId { get; set; }
        public int HostUserId_FK { get; set; }
        public int InvitedUserId_FK { get; set; }
        public int EventId_FK { get; set; }
        public bool CouplesEventApproved { get; set; }
        public int RequestAccepted { get; set; }

        public Event Evento { get; set; } = new Event();
        public User HostUser { get; set; } = new User();
        public User InvitedUser { get; set; } = new User();


    }
}