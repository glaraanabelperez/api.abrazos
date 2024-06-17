using Abrazos.Persistence.Database;
using Abrazos.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using ServicesQueries.Dto;
using System;
using System.Security.Cryptography;
using System.Xml.Linq;
using Utils;

namespace Abrazos.Services
{
    public class UserQueryService :IUserQueryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        ILogger _logger;

        private bool state = true;//Luego agregar en appsettings

        public UserQueryService(ApplicationDbContext context, ILogger<UserQueryService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }     
        /// <summary>
        /// Get Alll user - active and not active
        /// </summary>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <param name="name"></param>
        /// <param name="userName"></param>
        /// <param name="userStates"></param>
        /// <param name="cityId"></param>
        /// <param name="countryId"></param>
        /// <returns> Devuelve Usuario con permisos e informacion personal- </returns>
        public async Task<DataCollection<UserDto>> GetAllAsync(
            int page = 1, 
            int take = 500, 
            string? name = null, 
            string? userName = null, 
            bool? userStates = null, 
            int? cityId = null,
            string? countryId = null
            )
        {
            var queryable = await _context.User
                            .Include(a => a.Address)
                            .ThenInclude(x => x.City)
                            .ThenInclude(x => x.Country)
                           .Include(a => a.UserPermissions)
                               .ThenInclude(perm => perm.Permission) //Pueden pedir todos los usuarios organizadores o solo followers?
                            .Include(tyeu => tyeu.TypeEventsUsers)
                                .ThenInclude(tye => tye.TypeEvent)

                  .Where(x => name == null || !name.Any() || name.Contains(x.Name))
                  .Where(x => userName == null || !userName.Any() || userName.Contains(x.UserName))
                  .Where(x => userStates == null || (x.UserState != null && x.UserState == userStates))
                  .Where(x => cityId == null || (x.Address.FirstOrDefault().City.CityId == cityId))
                  .Where(x => string.IsNullOrEmpty(countryId) || (x.Address.FirstOrDefault().City.Country.CountryId.Equals(countryId)))

                  .OrderByDescending(x => x.Name)
                  .GetPagedAsync(page, take);

            _logger.LogInformation(queryable.ToString());

            var result = _mapper.Map<DataCollection<UserDto>>(queryable);


            return result;
        }

        public async Task<UserDto> GatAsync(int userId)
        {

            var queryable = (await _context.User
                                .Include(p => p.ProfileDancer)
                                    .ThenInclude(d => d.DanceRol)
                                .Include(p => p.ProfileDancer)
                                    .ThenInclude(d => d.DanceLevel)
                                .Include(a => a.Address)
                                .ThenInclude(x => x.City)
                                .ThenInclude(x => x.Country)
                               .Include(a => a.UserPermissions)
                                   .ThenInclude(perm => perm.Permission) 
                                .Include(tyeu => tyeu.TypeEventsUsers)
                                    .ThenInclude(tye => tye.TypeEvent)
            .SingleOrDefaultAsync(x => x.UserId == userId));
            _logger.LogWarning(queryable.ToString());
            return _mapper.Map<UserDto>(queryable);
 
        }

        /// <summary>
        /// Get User con su perfil completo, pudiendo filtrar por ubicacion del mismo, por intereses (EventType) 
        /// e incluso Rol y niveles en el baile -
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userName"></param>
        /// <param name="danceLevel"></param>
        /// <param name="danceRol"></param>
        /// <param name="evenType"></param>
        /// <param name="cityId"></param>
        /// <param name="countryId"></param>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns>Devuelve Usuario con Perfil profesional - </returns>
        public async Task<DataCollection<UserProfileDto>> GetAllUserProfileAsync(
           int page = 1,
           int take = 500,
           string? name = null,
           string? userName = null,
           int? danceLevel = null,
           int? danceRol = null,
           int? evenType = null,
           int? cityId = null,
           string? countryId = null
           )
        {
            var queryable = await _context.User
                              .Include(a => a.Address)
                                .ThenInclude(x => x.City)
                                .ThenInclude(x => x.Country)
                           .Include(a => a.ProfileDancer)
                               .ThenInclude(details => details.DanceRol)
                           .Include(a => a.ProfileDancer)
                               .ThenInclude(details => details.DanceLevel)
                            .Include(tyeu => tyeu.TypeEventsUsers)
                                .ThenInclude(tye => tye.TypeEvent)

                  .Where(x => name == null || !name.Any() || name.Contains(x.Name))
                  .Where(x => userName == null || !userName.Any() || userName.Contains(x.UserName))
                  .Where(x => x.UserState == state)
                  .Where(x => danceLevel == null || (x.ProfileDancer.First().DanceLevel != null && x.ProfileDancer.First().DanceLevel.DanceLevelId == danceLevel))
                  .Where(x => danceRol == null || (x.ProfileDancer.First().DanceRol != null && x.ProfileDancer.First().DanceRol.DanceRolId == danceRol))
                  .Where(x => cityId == null || (x.Address.First().City.CityId == cityId))
                  .Where(x => string.IsNullOrEmpty(countryId) || (x.Address.First().City.Country.CountryId.Equals(countryId)))
                  .Where(x => evenType == null || (x.TypeEventsUsers != null && x.TypeEventsUsers.First().TypeEvent.TypeEventId == evenType))

                  .OrderByDescending(x => x.Name)
                  .GetPagedAsync(page, take);

            _logger.LogInformation(queryable.ToString());

            var result = mapToProfileDancerDto(queryable);


            return result;
        }

        public DataCollection<UserProfileDto> mapToProfileDancerDto(DataCollection<User> query)
        {
            DataCollection<UserProfileDto> profiles = new DataCollection<UserProfileDto>();
            profiles.Total = query.Total;
            profiles.Page = query.Page;
            profiles.Items =
                query.Items.Select(x => new UserProfileDto()
                {
                      UserId = x.UserId,
                      Name = x.Name,
                      LastName= x.LastName,
                      UserName = x.UserName,
                      AvatarImage = x.AvatarImage,
                      UserState = x.UserState,
                      ProfileDancer = x.ProfileDancer.Select(x => new ProfileDancerDto()
                      {
                            ProfileDanceId =x.ProfileDanceId,
                            DanceLevelId =x.DanceLevelId,
                            DanceRolId = x.DanceRolId,
                            DanceRol = new DanceRolDto() { DanceRolId = x.DanceRolId, Name = x.DanceRol.Name },
                            DanceLevel = new DanceLevelDto() { DanceLevelId= x.DanceLevelId, Name = x.DanceLevel.Name },
                        }).ToList(),
                      Userlanguages= x.Userlanguages.Select(x => new UserLanguageDto()
                      {
                            UserLanguageId = x.UserLanguageId,
                            LanguageId = x.LanguageId,
                            LanguageName = x.Language.Name
                       }).ToList(),
                }).ToList();

            return profiles;
        }

        //public async Task<ResultApp> LoginAsync(string email, string pass)
        //{
        //    ResultApp res = new ResultApp();
        //    try
        //    {
        //        var queryable = await _context.User
        //                             .Where(x => x.Email == email)
        //                             .Where(x => x.Pass == pass)
        //                             .SingleOrDefaultAsync();

        //        if (queryable != null)
        //        {
        //            res.Succeeded = true;
        //            res.message = "Successful login";
        //            return res;
        //        }
        //        else
        //        {
        //            res.Succeeded = false;
        //            res.message = "UnSuccessful login";
        //            return res;
        //        }

        //        //_logger.LogWarning(res_.Metadata.ToString());

        //    }
        //    catch (System.Exception ex)
        //    {
        //        string exMessage = ex.InnerException != null ? ex.InnerException!.Message : ex.Message;
        //        _logger.LogWarning(exMessage);
        //        res.Succeeded = false;
        //        res.message = "Error in Login";
        //        res.errors = new ErrorResult
        //        {
        //            type = ex.GetType().Name,
        //            title = exMessage,
        //            status = "500",
        //            traceId = Guid.NewGuid().ToString(),
        //            errors = new Dictionary<string, List<string>>
        //            {
        //                    {"GetError : Failed to Get User ", new List<string> { exMessage }}
        //                }
        //        };

        //        return res;
        //    }
        //}

    }
}