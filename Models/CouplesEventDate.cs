using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CouplesEventDate 
    {
        public int CouplesEventId { get; set; }
        public int HostUserId { get; set; }
        public int InvitedUserId { get; set; }
        public int EventId { get; set; }
        public bool CouplesEventApproved { get; set; }
        public int RequestAccepted { get; set; }
        public int RequestRejected{ get; set; }

        public Event Evento { get; set; } = new Event();
        public User HostUser { get; set; } = new User();
        public User InvitedUser { get; set; } = new User();


    }
}