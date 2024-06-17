using ServicesQueries.Dto;
using Utils;

namespace Abrazos.Services.Interfaces
{
    public interface IUserQueryService
    {
        Task<DataCollection<UserDto>> GetAllAsync(
                                                    int page = 1,
                                                    int take = 500,
                                                    string? name = null,
                                                    string? userName = null,
                                                    bool? userStates = null,
                                                    int? cityId = null,
                                                    string? countryId = null
                                                );

        Task<UserDto> GatAsync(int userId);
        Task<DataCollection<UserProfileDto>> GetAllUserProfileAsync(
                                                   int page = 1,
                                                   int take = 500,
                                                   string? name = null,
                                                   string? userName = null,
                                                   int? danceLevel = null,
                                                   int? danceRol = null,
                                                   int? evenType = null,
                                                   int? cityId = null,
                                                   string? countryId = null
                                                    );
    }

}
    