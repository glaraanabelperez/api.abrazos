using Abrazos.Persistence.Database;
using Abrazos.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using ServicesQueries.Dto;
using System;
using Utils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Abrazos.Services
{
    public class ProfileDancerQueryService : IProfileDancerQueryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        ILogger _logger;

        public ProfileDancerQueryService(ApplicationDbContext context, ILogger<ProfileDancerQueryService> logger, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<ProfileDancerDto> GatAsync(int profileId)
        {

            var queryable = await _context.ProfileDancer
                                        .Include(x => x.DanceRol)
                                        .Include(x => x.DanceLevel)
                                        .SingleAsync(x => x.ProfileDanceId == profileId);

            var profile = _mapper.Map<ProfileDancerDto>(queryable);


            return profile;
 
        }

    }
}