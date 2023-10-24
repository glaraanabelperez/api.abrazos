using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.CreateCommand
{
    public class ImageCreateCommand
    {
        [Required]
        public int UserId_fk { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Name { get; set; } = string.Empty;
       
    }
}