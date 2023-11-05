using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<CityDto> Cities { get; set; } = new List<CityDto>();

    }
}