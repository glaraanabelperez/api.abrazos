using ServicesQueries.Dto;
using Utils;

namespace Abrazos.Services.Interfaces
{
    public interface IProfileDancerQueryService
    {
        Task<ProfileDancerDto> GatAsync(int profileId);

    }

}
    