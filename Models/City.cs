using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class City
    {
        public int CityId { get; set; }
        public int CountryId_FK { get; set; }
        public string Name { get; set; }

        public Country? Country { get; set; }

        public ICollection<Address>? Address { get; set; } = null;

    }
}