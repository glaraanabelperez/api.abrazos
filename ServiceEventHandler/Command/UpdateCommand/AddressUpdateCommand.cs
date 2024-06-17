using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace ServiceEventHandler.Command.UpdateCommand
{
    public class AddressUpdateCommand
    {
        public int CityId { get; set; }
        [MaxLength(255)]
        public string? Street { get; set; }
        [MaxLength(255)]
        public string? Number { get; set; } 
        public string? DetailAddress { get; set; } 
        public string? VenueName { get; set; } 
       
    }
}