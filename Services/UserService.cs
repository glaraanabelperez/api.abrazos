

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing.Printing;
using System.Linq;
using System.Xml.Linq;

namespace Abrazos.Services
{
    public class UserService :IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        ILogger<UserService> _logger;

        public UserService(ApplicationDbContext context, IMapper mapper, ILogger<UserService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
       
        public Task<DataCollection<UserDto>> GetAllAsync(int page, int take, string? name, string? userName, string? lastName, string? name_, byte? userStates)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GatAsync(long userId)
        {
            var data = (await _context.Users
                .SingleOrDefaultAsync(x => x.UserId == userId));

            var result = _mapper.Map<UserDto>(data);
            return result;
        }
    }
}