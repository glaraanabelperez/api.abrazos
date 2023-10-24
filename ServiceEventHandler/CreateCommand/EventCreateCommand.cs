using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.CreateCommand
{
    public class EventCreateCommand
    {
        [Required]
        public int UserIdCreator_FK { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 8)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? AddressId_fk { get; set; }
        public string? Image { get; set; }
        [Required]
        public DateTime DateInit { get; set; }
        [Required]
        public DateTime DateFinish { get; set; }
        public int EventStateId_fk { get; set; } = 1;
        [Required]
        public int TypeEventId_fk { get; set; }


    }
}