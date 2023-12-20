

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
        public IGenericRepository command;

        public ProfileDancerCommandHandler(ApplicationDbContext dbContext, IGenericRepository command, 
            ILogger<ProfileDancerCommandHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            this.command = command;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultApp<UserDto>> Add(ProfileDancerCreateCommand command)
        {
            ResultApp<UserDto> res = new ResultApp<UserDto>();
            try
            {
                var resProfile = await this.command.Add<ProfileDancer>(MapToProfileEntity(command));
                User user = _dbContext.User.FirstOrDefault(u => u.UserId == command.UserId);

                if (resProfile != null)
                {
                    user.ProfileDancerId_FK = resProfile.ProfileDanceId;
                    res.objectResult = _mapper.Map<UserDto>(await this.command.Update<User>(user));
                    res.Succeeded = true;
                }
            }
            catch(Exception ex)
            {
                res.message = ex.Message;
            }

            return res;

        }

        public async Task<ResultApp<ProfileDancer>> Update(ProfileDancerUpdateCommand command)
        {
            //ResultApp<ProfileDancer> res = new ResultApp<ProfileDancer>();
            //try
            //{
            //    ProfileDancer profile = _dbContext.ProfileDancer.FirstOrDefault(u => u.ProfileDanceId == command.ProfileDanceId);

            //    if (profile != null)
            //    {

            //        await this.command.Update<ProfileDancer>(UpdateEntity(profile, command));
            //        res.Succeeded = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    res.message = ex.Message;
            //}

            return null;



        }

        public ProfileDancer UpdateEntity(ProfileDancer profile, ProfileDancerUpdateCommand comand_)
        {
            profile.DanceRol_FK = comand_.DanceRol_FK != 0 ? comand_.DanceRol_FK : profile.DanceRol_FK;
            profile.DanceLevel_FK = comand_.DanceLevel_FK != 0 ? comand_.DanceLevel_FK : profile.DanceLevel_FK;
            profile.Height = comand_.Height.HasValue ? comand_.Height : profile.Height;
            return profile;
        }//este es el unico que funciona con el iGenericRepository, verificar qque ande bien

        public ProfileDancer MapToProfileEntity(ProfileDancerCreateCommand comand_)
        {
            ProfileDancer entity = new ProfileDancer();
            entity.DanceRol_FK = comand_.DanceRol_FK;
            entity.DanceLevel_FK = comand_.DanceLevel_FK;

            return entity;
        }


    }

}

