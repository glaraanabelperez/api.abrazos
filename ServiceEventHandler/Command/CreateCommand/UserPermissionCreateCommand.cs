using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class UserPermissionCreateCommand
    {
        [Required]
        public int UserId_FK { get; set; }
        [Required]
        public int Permission_FK { get; set; }

    }
}