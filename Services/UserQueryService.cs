

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;


namespace Abrazos.Services
{
    public class UserQueryService :IUserQueryService
    {
        private readonly IMapper _mapper;
        ILogger<UserQueryService> _logger;

        public UserQueryService(ApplicationDbContext context, ILogger<UserQueryService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
        }
       
        public Task<DataCollection<UserDto>> GetAllAsync(int page, int take, string? name, string? userName, string? lastName, string? name_, byte? userStates)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GatAsync(long userId)
        {
           
            return null;
        }
    }
}