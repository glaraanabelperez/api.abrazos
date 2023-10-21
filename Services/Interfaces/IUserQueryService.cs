using Abrazos.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Abrazos.Services.Interfaces
{
    public interface IUserQueryService
    {
        public Task<DataCollection<UserDto>> GetAllAsync(
                                                                int page,
                                                                int take,                                                                                                                             string? name,
                                                                string? userName,
                                                                string? lastName,
                                                                string? name_,
                                                                byte? userStates
                                                            );

        public Task<UserDto> GatAsync(long userId);


    }

}
    