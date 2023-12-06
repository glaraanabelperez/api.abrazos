using Abrazos.Services.Dto;
using ServicesQueries.Auth;
using System.ComponentModel.DataAnnotations;
using Utils;

namespace Abrazos.Services.Interfaces
{
    public interface IProfileDancerQueryService
    {
        Task<DataCollection<ProfileDancerDto>> GetAllAsync(
                                                    int page = 1,
                                                    int take = 50
                                              );

        Task<ResultApp> GatAsync(long profileId);
    }

}
    