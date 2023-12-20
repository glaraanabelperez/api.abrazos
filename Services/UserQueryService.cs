

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using ServicesQueries.Auth;
using System;
using System.Linq;
using System.Xml.Linq;
using Utils;

namespace Abrazos.Services
{
    public class UserQueryService :IUserQueryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        ILogger _logger;

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
                           .Include(a => a.ProfileDancer)
                               .ThenInclude(details => details.DanceRol)
                           .Include(a => a.ProfileDancer)
                               .ThenInclude(details => details.DanceLevel)
                            .Include(tyeu => tyeu.TypeEventsUsers)
                                .ThenInclude(tye => tye.TypeEvent)

                  .Where(x => name == null || !name.Any() || name.Contains(x.Name))
                  .Where(x => userName == null || !userName.Any() || userName.Contains(x.UserName))
                  .Where(x => userStates == null || (x.UserState != null && x.UserState == userStates))
                  .Where(x => danceLevel == null || (x.ProfileDancerId_FK != null && x.ProfileDancer.DanceLevel.DanceLevelId == danceLevel))
                  .Where(x => danceRol == null || (x.ProfileDancerId_FK != null && x.ProfileDancer.DanceRol.DanceRolId == danceRol))
                  .Where(x => evenType == null || (x.TypeEventsUsers != null && x.TypeEventsUsers.First().TypeEvent.TypeEventId == evenType))

                  .OrderByDescending(x => x.Name)
                  .GetPagedAsync(page, take);
            //.Skip((page - 1) * take)
            //.Take(take)
            //.ToListAsync();

            _logger.LogInformation(queryable.ToString());

            var result = _mapper.Map<DataCollection<UserDto>>(queryable);


            return result;
        }

        public async Task<ResultApp<UserDto>> GatAsync(long userId)
        {
            ResultApp<UserDto> resultApp = new ResultApp<UserDto>();
            try
            {

                var queryable = (await _context.User
                              .Include(a => a.UserPermissions)
                                  .ThenInclude(perm => perm.Permission)
                              .Include(a => a.ProfileDancer)
                                  .ThenInclude(details => details.DanceRol)
                              .Include(a => a.ProfileDancer)
                                  .ThenInclude(details => details.DanceLevel)
                              .Include(tyeu => tyeu.TypeEventsUsers)
                                .ThenInclude(tye => tye.TypeEvent)
                            .Include(ad => ad.Address)
                //.ThenInclude(tye => tye.TypeEvent)
                .SingleOrDefaultAsync(x => x.UserId == userId));

                if (queryable != null)
                {
                    resultApp.Succeeded = true;
                    resultApp.objectResult = _mapper.Map<UserDto>(queryable);
                    _logger.LogWarning(queryable.ToString());
                }
                else
                {
                    resultApp.message = "Without Data";
                }

                return resultApp;

            }
            catch (System.Exception ex)
            {
                string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
                _logger.LogWarning(value);
                resultApp.errors = value;
                resultApp.Succeeded = false;
                return resultApp;
            }


        }

        public async Task<ResultApp<UserDto>> LoginAsync(string email, string pass)
        {

            ResultApp<UserDto> res = new ResultApp<UserDto>();
            try
            {
                var queryable = await _context.User
                                     .Where(x => x.Email == email)
                                     .Where(x => x.Pass == pass)
                                     .SingleOrDefaultAsync();

                if (queryable != null)
                {
                    res.Succeeded = true;
                    res.message = "Successful login";
                    return res;
                }
                else
                {
                    res.Succeeded = false;
                    res.errors = "The user is not registered";
                    return res;
                }

                //_logger.LogWarning(res_.Metadata.ToString());

            }
            catch (System.Exception ex)
            {
                string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
                _logger.LogWarning(value);
                res.Succeeded = false;
                res.errors = "Error in Login";
                return res;
            }

        }


    }
}