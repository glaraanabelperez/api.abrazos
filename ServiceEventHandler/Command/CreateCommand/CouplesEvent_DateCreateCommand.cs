using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class CouplesEvent_DateCtreateCommand
    {
        [Required]
        public int HostUserId_FK { get; set; }
        [Required]
        public int InvitedUserId_FK { get; set; }
        [Required]
        public int EventId_FK { get; set; }
        public bool? CouplesEventApproved { get; set; }
        public int? RequestAccepted { get; set; }

    }
}