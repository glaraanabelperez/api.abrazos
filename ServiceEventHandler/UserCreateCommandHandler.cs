

using Abrazos.Persistence.Database;
using Abrazos.ServiceEventHandler.Commands;
using Abrazos.Services.Dto;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Models;
using ServiceEventHandler.Command;
using System.Net.NetworkInformation;

namespace Abrazos.ServiceEventHandler
{
    public class UserCreateCommandHandler: IUserCreateCommandHandler
    {
        private readonly ILogger<UserCreateCommandHandler> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public IGenericRepository command;

        public UserCreateCommandHandler(ApplicationDbContext dbContext, IGenericRepository command, 
            ILogger<UserCreateCommandHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            this.command = command;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultApp> AddUser(UserCreateCommand entity)
        {
           //ResultApp result = new ResultApp();
           try
           {
               var entity_ = _mapper.Map<User>(entity);
               var res = await this.command.Add<User>(entity_);
               //res.objectResult = _mapper.Map<UserDto>(res.objectResult);
               return res ;
           }
           catch (System.Exception ex)
           {
               string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
               _logger.LogWarning(value);
                return null;

            }


        }


    
    }
}

