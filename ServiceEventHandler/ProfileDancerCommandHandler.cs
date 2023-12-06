

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
    public class ProfileDancerCommandHandler: IProfileDancerCommandHandler
    {
        private readonly ILogger<ProfileDancerCommandHandler> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public IGenericRepository<ProfileDancer> command;

        public ProfileDancerCommandHandler(ApplicationDbContext dbContext, IGenericRepository<ProfileDancer> command, 
            ILogger<ProfileDancerCommandHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            this.command = command;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultApp> Add(ProfileDancerCreateCommand command)
        {
            ResultApp res = new ResultApp();
            try
            {
                var resProfile = await this.command.Add<ProfileDancer>(MapToProfileEntity(command));
                User user = _dbContext.User.FirstOrDefault(u => u.UserId == command.UserId);

                if (resProfile != null)
                {
                    user.ProfileDancerId_FK = resProfile.ProfileDanceId;
                    var userResult_ = await this.command.Update<User>(user);
                    res.objectResult = _mapper.Map<UserDto>(userResult_);
                }
            }
            catch(Exception ex)
            {
                res.message = ex.Message;
            }

            return res;

        }

        public Task<ResultApp> AddProfile(ProfileDancerCreateCommand entity)
        {
            throw new NotImplementedException();
        }

        //public async Task<ResultApp> UpdateProfile(ProfileDancerCreateCommand command)
        //{
        //    ResultApp res = null;
        //    var result = _dbContext.User
        //        .FirstOrDefault(u => u.UserId == command.UserId);

        //    if (result != null)
        //    {
        //       res = await this.command.Update<User>(MapToUserEntityInUpdate(result, command));
        //    }
        //    return res;

        //}

        //public User MapToUserEntityInUpdate(User user, UserUpdateCommand userCommand)
        //{
        //    user.UserName = (userCommand.UserName != null && userCommand.UserName != string.Empty) ? userCommand.UserName : user.UserName;
        //    user.Email = (userCommand.Email != null && userCommand.Email != string.Empty) ? userCommand.Email : user.Email;
        //    user.Celphone = ( userCommand.Celphone != null && userCommand.Celphone != string.Empty) ? userCommand.Celphone : user.Celphone;
        //    user.Age = userCommand.Age != 0 ? userCommand.Age : user.Age;
        //    user.AvatarImage = (userCommand.AvatarImage != null && userCommand.AvatarImage != string.Empty) ? userCommand.AvatarImage : user.AvatarImage;
        //    user.LastName = (userCommand.LastName != null && userCommand.LastName != string.Empty )? userCommand.LastName : user.LastName;
        //    user.Name = (userCommand.Name != null && userCommand.Name != string.Empty) ? userCommand.Name : user.Name;
        //    user.Pass = (userCommand.Pass != null && userCommand.Pass != string.Empty )? userCommand.Pass : user.Pass;

        //    return user;
        //}

        public ProfileDancer MapToProfileEntity(ProfileDancerCreateCommand comand_)
        {
            ProfileDancer entity = new ProfileDancer();
            entity.DanceRol_FK = comand_.DanceRol_FK;
            entity.DanceLevel_FK = comand_.DanceLevel_FK;

            return entity;
        }

        public Task<ResultApp> UpdateProfile(ProfileDancerUpdateCommand entity)
        {
            throw new NotImplementedException();
        }
    }
}

