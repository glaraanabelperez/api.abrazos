using Abrazos.Services.Dto;
using ServicesQueries.Auth;
using System.ComponentModel.DataAnnotations;
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
                                                    int? danceLevel = null,
                                                    int? danceRol = null,
                                                    int? evenType = null
                                              );

        Task<ResultApp<UserDto>> GatAsync(long userId);
        Task<ResultApp<UserDto>> LoginAsync(string email, string pass);
    }

}
    