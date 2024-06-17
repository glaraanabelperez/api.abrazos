using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class CouplesEvent_DateCtreateCommand
    {
        [Required]
        public int HostUserId { get; set; }
        [Required]
        public int InvitedUserId{ get; set; }
        [Required]
        public int EventId { get; set; }
        public bool? CouplesEventApproved { get; set; }
        public int? RequestAccepted { get; set; }

    }
}