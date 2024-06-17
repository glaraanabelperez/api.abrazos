using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class City
    {
        public int CityId { get; set; }
        public char CountryId { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public Country Country { get; set; }

        public ICollection<Address> Address { get; set; } = new List<Address>();

    }
}