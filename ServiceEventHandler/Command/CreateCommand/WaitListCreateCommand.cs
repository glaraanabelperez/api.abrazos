using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class WaitListCreateCommand
    {
        [Required]
        public int UserId_FK { get; set; }
        [Required]
        public int EventId_FK { get; set; }
        public int State { get; set; }

    }
}