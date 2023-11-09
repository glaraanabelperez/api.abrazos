using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class TypeEvent_UserCreateCommand
    {
        [Required]
        public int TypeEventId_FK { get; set; }
        [Required]
        public int UserId_FK { get; set; }

    }
}