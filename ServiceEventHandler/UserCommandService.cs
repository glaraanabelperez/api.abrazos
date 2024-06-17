

using Abrazos.Persistence.Database;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Models;
using ServiceEventHandler.Command.CreateCommand;
using Utils;

namespace Abrazos.ServiceEventHandler
{
    public class UserCommandService: IUserCommandService
    {
        private readonly ILogger<UserCommandService> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public IGenericRepository command;

        public UserCommandService(ApplicationDbContext dbContext, IGenericRepository command, 
            ILogger<UserCommandService> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            this.command = command;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultApp> AddUser(UserCreateCommand entity)
        {

            ResultApp res = new ResultApp();
            await this.command.Add<User>(MapToUserEntity(entity));
            res.Succeeded = true;
            return res;

        }

        public async Task<ResultApp> UpdateUser(UserUpdateCommand command)
        {
            ResultApp res = new ResultApp();

            var result = _dbContext.User
                .FirstOrDefault(u => u.UserId == command.userId);
            if (result != null)
            {
                User user_res = await this.command.Update<User>(MapToUserEntityInUpdate(result, command));
                res.Succeeded = true;
                res.message = "Update Successfull";

            }
            return res;

        }

        public User MapToUserEntityInUpdate(User user, UserUpdateCommand entity_)
        {
            user.UserName = entity_.UserName ?? user.UserName;
            user.Email = entity_.Email ?? user.Email;
            user.Celphone = entity_.Celphone ?? user.Celphone;
            user.Age = entity_.Age?? user.Age ;
            user.AvatarImage = entity_.AvatarImage ?? user.AvatarImage;
            user.LastName = entity_.LastName ?? user.LastName;
            user.Name = entity_.Name ?? user.Name;
            user.UserIdFirebase = entity_.UserIdFirebase ?? user.UserIdFirebase;
            user.UserState = true; //datos en appsetting
            user.Description = entity_.Description ?? user.Description;
            user.Height = entity_.Height ?? user.Height;
            user.UserIdFirebase = entity_.UserIdFirebase ??  user.UserIdFirebase;
            if (entity_.TypeEvents.Count() > 0)
            {
                user.TypeEventsUsers = entity_.TypeEvents.Select(ty => new TypeEventUser()
                {
                    TypeEventId = ty

                }).ToList();
            }

            if (entity_.Addresses != null)
            {
                user.Address = entity_.Addresses.Select(ad => new Address()
                {
                    DetailAddress = ad.DetailAddress,
                    CityId = ad.CityId,
                    Street = ad.Street,
                    Number = ad.Number,
                    VenueName = ad.VenueName,
                    StateAddress = true

                }).ToList();
            }
            return user;
        }

        public User MapToUserEntity(UserCreateCommand entity_)
        {
            User user = new User();
            user.UserName = entity_.UserName;
            user.Email = entity_.Email;
            user.Celphone = entity_.Celphone;
            user.Age = entity_.Age;
            user.AvatarImage = entity_.AvatarImage??null;
            user.LastName = entity_.LastName;
            user.Name = entity_.Name;
            user.UserIdFirebase = entity_.UserIdFirebase;
            user.UserState = true; //datos en appsetting
            user.Description= entity_.Description;
            user.Height = entity_.Height;
            user.TypeEventsUsers = entity_.TypeEvents != null && entity_.TypeEvents.Count() > 0 ? entity_.TypeEvents.Select(ty => new TypeEventUser()
            {
                TypeEventId=ty

            }).ToList() : null;
            user.Address = entity_.Addresses != null && entity_.Addresses.Count() > 0 ? entity_.Addresses.Select(ad => new Address()
            {
                DetailAddress = ad.DetailAddress,
                CityId = ad.CityId,
                Street = ad.Street,
                Number = ad.Number,
                VenueName = ad.VenueName,
                StateAddress = true

            }).ToList() : null;
            return user;
        }

 
    }
}

