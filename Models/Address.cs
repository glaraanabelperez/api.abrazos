using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string? VenueName { get; set; }
        public string DetailAddress { get; set; }
        public bool StateAddress { get; set; }  
        public City City { get; set; } 
        public ICollection<Event>? Events { get; set; } = new List<Event>();


    }
}