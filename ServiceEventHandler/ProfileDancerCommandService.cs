

using Abrazos.Persistence.Database;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Models;
using ServiceEventHandler.Command.CreateCommand;
using Utils;

namespace Abrazos.ServiceEventHandler
{
    public class ProfileDancerCommandService: IProfileDancerCommandService
    {

        private readonly ILogger<ProfileDancerCommandService> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public IGenericRepository command;

        public ProfileDancerCommandService(ApplicationDbContext dbContext, IGenericRepository command,
           ILogger<ProfileDancerCommandService> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            this.command = command;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultApp> Add(ProfileDancerCreateCommand command)
        {
            ResultApp res = new ResultApp();

            User user = _dbContext.User.FirstOrDefault(u => u.UserId == command.UserId);
            if (user != null)
            {
                // AddRange is not in Generci Repository.
                _dbContext.AddRange(MapToEntity(command));
                _dbContext.SaveChanges();
                res.Succeeded = true;
            }
            else
            {
                res.errors = null;
                res.Succeeded = false;
                res.message = "El usuario no existe";
            }
                    
            return res;

        }

        public ICollection<ProfileDancer> MapToEntity(ProfileDancerCreateCommand command_)
        {
            ICollection<ProfileDancer> profiles = new List<ProfileDancer>();

            foreach (var e in command_.DancerSkils)
            {
                ProfileDancer entity = new ProfileDancer();
                entity.UserId = command_.UserId;
                entity.DanceRolId = e.DanceRolId;
                entity.DanceLevelId = e.DanceLevelId;
                profiles.Add(entity);
            }

            return profiles;
        }

        /// <summary>
        /// Send entity to update in Generic Repository.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<ResultApp> Update(ProfileDancerUpdateCommand command)
        {
            ResultApp res = new ResultApp();
            ProfileDancer profile = null;

            profile = _dbContext.ProfileDancer.FirstOrDefault(u => u.ProfileDanceId == command.ProfileDancerId);


            if (profile != null)
            {

                await this.command.Update<ProfileDancer>(MapToUpdateEntity(profile, command));
                res.Succeeded = true;
            }
            else
            {
                res.Succeeded = false;
                res.message = "El usuario no tiene este perfil asociado";
            }

           
            return res;
                
        }

        public async Task<ResultApp> DeleteAsync(int profileDancerId)
        {
            ResultApp res = new ResultApp();
            ProfileDancer profile = null;

            profile = _dbContext.ProfileDancer.SingleOrDefault(u => u.ProfileDanceId == profileDancerId);

            if (profile != null)
            {

                await this.command.Delete<ProfileDancer>(profile);
                res.Succeeded = true;
            }
            else
            {
                res.Succeeded = false;
                res.message = "El perfil no se encuentra";
            }

            return res;

        }

        public ProfileDancer MapToUpdateEntity(ProfileDancer profile, ProfileDancerUpdateCommand comand_)
        {

            profile.DanceRolId = comand_.DanceRolId  ??  profile.DanceRolId;
            profile.DanceLevelId = comand_.DanceLevelId ??  profile.DanceLevelId;
            return profile;
        }


    }

}

