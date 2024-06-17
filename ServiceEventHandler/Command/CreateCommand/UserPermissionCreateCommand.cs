using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class UserPermissionCreateCommand
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Permission { get; set; }

    }
}