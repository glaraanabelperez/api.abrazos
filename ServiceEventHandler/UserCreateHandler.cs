

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
    public class UserCreateHandler: IUserCreateHandler
    {
        private readonly ILogger<UserCreateHandler> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public IGenericRepository command;

        public UserCreateHandler(ApplicationDbContext dbContext, IGenericRepository command, 
            ILogger<UserCreateHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            this.command = command;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultApp> AddUser(UserCreateCommand entity)
        {
           ResultApp? result = null;
           try
           {
               var user = new User();
               user.Name= entity.UserName;
               user.UserState = 1;
               user.Pass = "1234";

               var object_= await this.command.Add<User>(user);
               result = new ResultApp(true, "Create OK", _mapper.Map<UserDto>(object_));
               return result;
           }
           catch (System.Exception ex)
           {
               string value = ((ex.InnerException != null) ? ex.InnerException!.Message : ex.Message);
               _logger.LogWarning(value);
           }

           return result;

        }


    
    }
}

