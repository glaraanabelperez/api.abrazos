

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

        public async Task<ResultApp<UserDto>> AddUser(UserCreateCommand entity)
        {

            ResultApp<UserDto> res = new ResultApp<UserDto>();
            try 
            { 
               var user_res = await this.command.Add<User>(MapToUserEntity(entity));
                res.objectResult = _mapper.Map<UserDto>(user_res);//mappear
                res.Succeeded = true;
            }
            catch (Exception ex) 
            { 
                res.message= ex.Message;
            }
           
            return res ;

        }

        public async Task<ResultApp<UserDto>> UpdateUser(UserUpdateCommand command)
        {
            ResultApp<UserDto> res = new ResultApp<UserDto>();
            var result = _dbContext.User
                .FirstOrDefault(u => u.UserId == command.userId);

            if (result != null)
            {
                var user_res = await this.command.Update<User>(MapToUserEntityInUpdate(result, command));
                res.objectResult = _mapper.Map<UserDto>(user_res);//mappear
                res.Succeeded = true;
                res.message = "Update Successfull";

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

            return user;
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
            user.UserState = true;

            if (entity_.ProfileDancer != null)
            {
                user.ProfileDancer.DanceRol_FK = entity_.ProfileDancer.DanceRol_FK;
                user.ProfileDancer.DanceLevel_FK = entity_.ProfileDancer.DanceLevel_FK;
                user.ProfileDancer.Height = entity_.ProfileDancer.Height;

            }

            return user;
        }


    }
}

