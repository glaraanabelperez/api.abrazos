

using Abrazos.Persistence.Database;
using Abrazos.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicesQueries.Dto;
using Utils;

namespace Abrazos.Services
{
    public class EventQueryService :IEventQueryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        ILogger _logger;

        public EventQueryService(ApplicationDbContext context, ILogger<UserQueryService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// GetAll By Cycle with Filters.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="organizerId"></param>
        /// <param name="CycleId"></param>
        /// <param name="danceLevel"></param>
        /// <param name="danceRol"></param>
        /// <param name="evenType"></param>
        /// <param name="CityId"></param>
        /// <param name="addressId"></param>
        /// <param name="countryId"></param>
        /// <param name="dateInit"></param>
        /// <param name="dateFinish"></param>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns>DataCollection<EventDto></EventDto></returns>
        public async Task<DataCollection<EventDto>> GetAllAsync(
            string? eventNameSearch,
            int? organizerId,
            int? CycleId,
            int? danceLevel,
            int? danceRol,
            int? evenType,
            int? CityId,
            int? addressId,
            string? countryId,
            DateTime? dateInit,
            DateTime? dateFinish,
            int page = 1,
            int take = 500
            )
        {
            var queryable =  _context.Event
                           .Include(e => e.Cycle)
                           .Include(e => e.EventState)
                           .Include(e => e.TypeEvent)
                           .Include(u => u.UserCreator)
                           .Include(l => l.Level)
                           .Include(r => r.Rol)
                  .Include(a => a.Address)
                      .ThenInclude(c => c.City)
                      .ThenInclude(c => c.Country)


                  .Where(x => (eventNameSearch == null || !eventNameSearch.Any() || eventNameSearch.Contains(x.Name) || (x.Cycle != null && eventNameSearch.Contains(x.Cycle.CycleTitle))))
                                  .Where(x => (organizerId == null || x.UserIdCreator == organizerId)
                                          && (CycleId == null || x.Cycle.CycleId == CycleId)
                                          && (danceLevel == null || x.LevelId == danceLevel)
                                          && (danceRol == null || x.RolId == danceRol)
                                          && (evenType == null || x.TypeEventId == evenType)
                                          && (CityId == null || x.Address.City.CityId == CityId)
                                          && (countryId == null || x.Address.City.CountryId.Equals(countryId))
                                          && (addressId == null || x.Address.AddressId == addressId)
                                          && (evenType == null || x.TypeEventId == evenType)
                                          && (dateInit == null || dateFinish == null || (dateInit >= x.DateInit && x.DateFinish >= dateFinish))

                                  )
                  .OrderByDescending(x => x.EventId);

            var cycles = _mapper.Map<DataCollection<EventDto>>(
                await queryable.GetPagedAsync(page, take));

            _logger.LogInformation(queryable.ToString());

            return cycles;
        }


        /// <summary>
        /// GetById
        /// </summary>
        /// <returns>EventDto</returns>
        public async Task<EventDto> GetAsync(int eventId)
        {
            var query = await _context.Event
                           .Include(e => e.Cycle)
                           .Include(e => e.EventState)
                           .Include(e => e.TypeEvent)
                           .Include(u => u.UserCreator)
                           .Include(l => l.Level)
                           .Include(r => r.Rol)
                           .Include(a => a.Address)
                               .ThenInclude(c => c.City)
                               .ThenInclude(c => c.Country)


            .Where(x => eventId == null || x.EventId == eventId)
            .SingleAsync();
            _logger.LogInformation(query.ToString());

            var event_ = _mapper.Map<EventDto>(query);


            return event_;
        }

    }
}


