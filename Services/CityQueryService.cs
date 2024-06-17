

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.Services.Interfaces;
using AutoMapper;
using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Models;
using ServicesQueries.Dto;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using Utils;

namespace Abrazos.Services
{
    public class CityQueryService :ICityQueryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        ILogger _logger;

        public CityQueryService(ApplicationDbContext context, ILogger<UserQueryService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public Task<DataCollection<CityDto>> GetAll(char? countryId)
        {
            throw new NotImplementedException();
        }

        public Task<DataCollection<CityDto>> GetAllCityWithEventsByCountry(string? name, char? countryId, int page = 1, int take = 500)
        {
            throw new NotImplementedException();
        }

        public Task<CityDto> GetAsync(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}


