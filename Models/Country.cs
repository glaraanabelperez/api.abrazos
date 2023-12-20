using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        //public ICollection<City>? Cities { get; set; } = null;

    }
}