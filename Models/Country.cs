using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<City> Cities = new List<City>();

    }
}