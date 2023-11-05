using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Dto
{
    public class CityDto
    {
        public int CityId { get; set; }
        public int CountryId_FK { get; set; }
        public string Name { get; set; } = null!;

        public CountryDto Country { get; set; } = new CountryDto();

        public ICollection<AddressDto> Address { get; set; } = new List<AddressDto>();

    }
}