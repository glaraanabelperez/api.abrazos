

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
           

           ResultApp res = await this.command.Add<User>(MapToUserEntity(entity));
           return res ;

        }

        public User MapToUserEntity(UserCreateCommand entity_)
        {
            User user = new User();
            user.UserName = entity_.UserName;
            user.Email = entity_.Email;
            user.Celphone = entity_.Celphone;
            user.Age = entity_.Age;
            user.AvatarImage = entity_.AvatarImage;
            user.LastName = entity_.LastName;
            user.Name = entity_.Name;        
            user.Pass = entity_.Pass;

            if (entity_.ProfileDancerCreateCommand != null)
            {
                user.ProfileDancers.DanceRol_FK = entity_.ProfileDancerCreateCommand.DanceRol_FK;
                user.ProfileDancers.DanceLevel_FK = entity_.ProfileDancerCreateCommand.DanceLevel_FK;


            }

            return user;
        }

    
    }
}

