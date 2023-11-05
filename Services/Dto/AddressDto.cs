using Models;

namespace Abrazos.Services.Dto
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public int UserId_FK { get; set; }
        public int CityId_FK { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string DetailAddress { get; set; }
        public bool StateAddress { get; set; }

        public CityDto City { get; set; } = new CityDto();

        public ICollection<EventDto> Events { get; set; } = new List<EventDto>();
    }
}