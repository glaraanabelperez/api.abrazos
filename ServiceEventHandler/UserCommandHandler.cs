

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Models;
using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using System.Net.NetworkInformation;
using Utils;

namespace Abrazos.ServiceEventHandler
{
    public class UserCommandHandler: IUserCommandHandler
    {
        private readonly ILogger<UserCommandHandler> _logger;
        private readonly ApplicationDbContext _dbContext;
        //private readonly IMapper _mapper;
        public IGenericRepository command;

        public UserCommandHandler(ApplicationDbContext dbContext, IGenericRepository command, 
            ILogger<UserCommandHandler> logger, IMapper mapper)
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

        public async Task<ResultApp> UpdateUser(UserUpdateCommand entity)
        {

            ResultApp res = await this.command.Update<User>(MapToUserEntity(entity));
            return res;

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
                user.ProfileDancers.Height = entity_.ProfileDancerCreateCommand.Height;

            }

            return user;
        }

    
    }
}

