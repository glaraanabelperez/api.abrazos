

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Xml.Linq;
using Utils;

namespace Abrazos.Services
{
    public class UserQueryService :IUserQueryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        ILogger<UserQueryService> _logger;

        public UserQueryService(ApplicationDbContext context, ILogger<UserQueryService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }
       
        public async Task<DataCollection<UserDto>> GetAllAsync(
            int page = 1, 
            int take = 500, 
            string? name = null, 
            string? userName = null, 
            bool? userStates = null, 
            int? danceLevel = null,
            int? danceRol = null,
            int? evenType = null
            )
        {
            var queryable = await _context.User
                           .Include(a => a.UserPermissions)
                               .ThenInclude(perm => perm.Permission)
                           .Include(a => a.ProfileDancers)
                               .ThenInclude(details => details.DanceRol)
                           .Include(a => a.ProfileDancers)
                               .ThenInclude(details => details.DanceLevel)
                            .Include(tyeu => tyeu.TypeEventsUsers)
                                .ThenInclude(tye => tye.TypeEvent)

                  .Where(x => name == null || !name.Any() || name.Contains(x.Name))
                  .Where(x => userName == null || !userName.Any() || userName.Contains(x.UserName))
                  .Where(x => userStates == null || (x.UserState != null && x.UserState == userStates))
                  .Where(x => danceLevel == null || (x.ProfileDancerId_FK != null && x.ProfileDancers.DanceLevel.DanceLevelId == danceLevel))
                  .Where(x => danceRol == null || (x.ProfileDancerId_FK != null && x.ProfileDancers.DanceRol.DanceRolId == danceRol))
                  .Where(x => evenType == null || (x.TypeEventsUsers != null && x.TypeEventsUsers.First().TypeEvent.TypeEventId == evenType))

                  .OrderByDescending(x => x.Name)
                  .GetPagedAsync(page, take);
                  //.Skip((page - 1) * take)
                  //.Take(take)
                  //.ToListAsync();

            var result = _mapper.Map<DataCollection<UserDto>>(queryable);


            return result;
        }

        public async Task<UserDto> GatAsync(long userId)
        {

            var queryable = await _context.User
                          .Include(a => a.UserPermissions)
                              .ThenInclude(perm => perm.Permission)
                          .Include(a => a.ProfileDancers)
                              .ThenInclude(details => details.DanceRol)
                          .Include(a => a.ProfileDancers)
                              .ThenInclude(details => details.DanceLevel)
                          .Include(tyeu => tyeu.TypeEventsUsers)
                            .ThenInclude(tye => tye.TypeEvent)
                        .Include(ad => ad.Address)
            //.ThenInclude(tye => tye.TypeEvent)
            .Where(x => x.UserId==userId)
            .SingleOrDefaultAsync();


            var result = _mapper.Map<UserDto>(queryable);


            return result;
        }


    }
}