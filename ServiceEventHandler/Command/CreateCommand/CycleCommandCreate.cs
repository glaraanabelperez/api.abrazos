using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.CreateCommand
{
    public class CycleCommandCreate
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Tittle { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Description { get; set; }
    }
}