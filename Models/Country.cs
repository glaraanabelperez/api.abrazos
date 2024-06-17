using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Country
    {
        public char CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();

    }
}