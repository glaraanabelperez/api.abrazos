using ServicesQueries.Dto;
using Utils;

namespace Abrazos.Services.Interfaces
{
    public interface ICityQueryService
    {
        public Task<DataCollection<CityDto>> GetAllCityWithEventsByCountry(
            string? name,
            char? countryId,
            int page = 1,
            int take = 500
        );
        public Task<DataCollection<CityDto>> GetAll(char? countryId);
        public Task<CityDto> GetAsync(int cityId);


    }

}
    