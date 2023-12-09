

using Abrazos.Persistence.Database;
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
        public IGenericRepository<ProfileDancerCreateCommand> command;

        public ProfileDancerCommandHandler(ApplicationDbContext dbContext, IGenericRepository<ProfileDancerCreateCommand> command, 
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
                    res.Succeeded = true;
                }
            }
            catch(Exception ex)
            {
                res.message = ex.Message;
            }

            return res;

        }

        public async Task<ResultApp> Update(ProfileDancerUpdateCommand command)
        {
            ResultApp res = new ResultApp();
            try
            {
                ProfileDancer profile = _dbContext.ProfileDancer.FirstOrDefault(u => u.ProfileDanceId == command.ProfileDanceId);

                if (profile != null)
                {

                    await this.command.Update<ProfileDancer>(UpdateEntity(profile, command));
                    res.Succeeded = true;
                }
            }
            catch (Exception ex)
            {
                res.message = ex.Message;
            }

            return res;



        }

        public ProfileDancer UpdateEntity(ProfileDancer profile, ProfileDancerUpdateCommand comand_)
        {
            profile.DanceRol_FK = comand_.DanceRol_FK != 0 ? comand_.DanceRol_FK : profile.DanceRol_FK;
            profile.DanceLevel_FK = comand_.DanceLevel_FK != 0 ? comand_.DanceLevel_FK : profile.DanceLevel_FK;
            profile.Height = comand_.Height.HasValue ? comand_.Height : profile.Height;
            return profile;
        }

        public ProfileDancer MapToProfileEntity(ProfileDancerCreateCommand comand_)
        {
            ProfileDancer entity = new ProfileDancer();
            entity.DanceRol_FK = comand_.DanceRol_FK;
            entity.DanceLevel_FK = comand_.DanceLevel_FK;

            return entity;
        }

    }
}

