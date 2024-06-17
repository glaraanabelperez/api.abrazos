

using Abrazos.Persistence.Database;
using Abrazos.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Models;
using ServicesQueries.Dto;
using System.Data.Entity;
using System.Linq;
using Utils;

namespace Abrazos.Services
{
    public class CountryQueryService : ICountryQueryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        ILogger _logger;

        public CountryQueryService(ApplicationDbContext context, ILogger<CountryQueryService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public Task<DataCollection<CountryDto>> GetAll(int page = 1, int take = 500)
        {
            throw new NotImplementedException();
        }

        public async Task<DataCollection<CountryDto>> GetAllCountryWithEvents(int page = 1,int take = 500)
        {
            var queryable =  _context.Conuntry
                                .Include(x => x.Cities.Any(c => c.Address.Any(e => e.Events.Count()>0)))
                                .OrderByDescending(x => x.Name);

            var result = _mapper.Map<DataCollection<CountryDto>>(
                            await queryable.GetPagedAsync(page, take));

            return result;
        }

        public Task<CountryDto> GetAsync(char countryId)
        {
            throw new NotImplementedException();
        }

    }
}


