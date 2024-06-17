using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class TypeEvent_UserCreateCommand
    {
        [Required]
        public int TypeEventId { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}