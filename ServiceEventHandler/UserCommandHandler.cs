

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Models;
using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using System.Data.Entity;
using System.Net.NetworkInformation;
using Utils;

namespace Abrazos.ServiceEventHandler
{
    public class UserCommandHandler: IUserCommandHandler
    {
        private readonly ILogger<UserCommandHandler> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
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


            ResultApp res = await this.command.Add<User>(_mapper.Map<User>(entity));
            return res ;

        }

        public async Task<ResultApp> UpdateUser(UserUpdateCommand command)
        {
            ResultApp res = null;
            var result = _dbContext.User
                //.Include(u => u.ProfileDancers)
                .FirstOrDefault(u => u.UserId == command.userId);

            if (result != null)
            {
               res = await this.command.Update<User>(MapToUserEntityInUpdate(result, command));
            }
            return res;

        }

        public User MapToUserEntityInUpdate(User user, UserUpdateCommand userCommand)
        {
            user.UserName = (userCommand.UserName != null && userCommand.UserName != string.Empty) ? userCommand.UserName : user.UserName;
            user.Email = (userCommand.Email != null && userCommand.Email != string.Empty) ? userCommand.Email : user.Email;
            user.Celphone = ( userCommand.Celphone != null && userCommand.Celphone != string.Empty) ? userCommand.Celphone : user.Celphone;
            user.Age = userCommand.Age != 0 ? userCommand.Age : user.Age;
            user.AvatarImage = (userCommand.AvatarImage != null && userCommand.AvatarImage != string.Empty) ? userCommand.AvatarImage : user.AvatarImage;
            user.LastName = (userCommand.LastName != null && userCommand.LastName != string.Empty )? userCommand.LastName : user.LastName;
            user.Name = (userCommand.Name != null && userCommand.Name != string.Empty) ? userCommand.Name : user.Name;
            user.Pass = (userCommand.Pass != null && userCommand.Pass != string.Empty )? userCommand.Pass : user.Pass;

            //if (userCommand.ProfileDancerUpdateCommand != null)
            //{
            //    user.ProfileDancers.DanceRol_FK = userCommand.ProfileDancerUpdateCommand.DanceRol.DanceRolId;
            //    user.ProfileDancers.DanceLevel_FK = userCommand.ProfileDancerUpdateCommand.DanceLevel.ProfileLevelId;
            //    user.ProfileDancers.Height = userCommand.ProfileDancerUpdateCommand.Height;

            //}

            return user;
        }

        //public User MapToUserEntity(UserCreateCommand entity_)//usar mapper!!
        //{
        //    User user = new User();
        //    user.UserName = entity_.UserName;
        //    user.Email = entity_.Email;
        //    user.Celphone = entity_.Celphone;
        //    user.Age = entity_.Age;
        //    user.AvatarImage = entity_.AvatarImage;
        //    user.LastName = entity_.LastName;
        //    user.Name = entity_.Name;        
        //    user.Pass = entity_.Pass;

        //    if (entity_.ProfileDancerCreateCommand != null)
        //    {
        //        user.ProfileDancers.DanceRol_FK = entity_.ProfileDancerCreateCommand.DanceRol_FK;
        //        user.ProfileDancers.DanceLevel_FK = entity_.ProfileDancerCreateCommand.DanceLevel_FK;
        //        user.ProfileDancers.Height = entity_.ProfileDancerCreateCommand.Height;

        //    }

        //    return user;
        //}


    }
}

