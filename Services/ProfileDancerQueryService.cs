

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Serilog;
using ServicesQueries.Auth;
using System;
using System.Linq;
using System.Xml.Linq;
using Utils;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Abrazos.Services
{
    public class ProfileDancerQueryService :IProfileDancerQueryService
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

        public async Task<ResultApp> GatAsync(long profileId)
        {
            ResultApp resultApp = new ResultApp();
            try
            {

                var queryable = (await _context.ProfileDancer
                                  .Include(details => details.DanceRol)
                                  .Include(details => details.DanceLevel)
                .SingleOrDefaultAsync(x => x.ProfileDanceId == profileId));

                if (queryable != null)
                {
                    resultApp.Succeeded = true;
                    resultApp.objectResult = _mapper.Map<ProfileDancerDto>(queryable);
                    //_logger.LogWarning(queryable.ToString());
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

        public Task<DataCollection<ProfileDancerDto>> GetAllAsync(int page = 1, int take = 50)
        {
            throw new NotImplementedException();
        }
    }
}