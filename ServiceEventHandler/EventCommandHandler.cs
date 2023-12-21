

using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Models;
using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using ServiceEventHandler.Validators;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Net.NetworkInformation;
using Utils;

namespace Abrazos.ServiceEventHandler
{
    public class EventCommandHandler: IEventCommandHandler
    {
        private readonly ILogger<EventCommandHandler> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public IGenericRepository commandGeneric;

        public EventCommandHandler(ApplicationDbContext dbContext, IGenericRepository command, 
            ILogger<EventCommandHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            this.commandGeneric = command;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultApp<Event>> Add(EventCreateCommand command)
        {
            ResultApp<Event> res = new ResultApp<Event>();

            if (ValidateCommand(command))
            {
                try
                {
                    var resEntity = await this.commandGeneric.Add<Event>(MapToEntity(command));
                    res.objectResult = resEntity;
                    res.Succeeded = true;
                }
                catch (Exception ex)
                {
                    res.message = ex.Message;
                }

            }

            return res;


        }

        public bool ValidateCommand(EventCreateCommand command)
        {
            var myModel = new IdOrObjectClassAttribute { id = command.AddressId_fk, objectCommand = command.Address };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(myModel, new ValidationContext(myModel), validationResults, true);

            if (isValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public async Task<ResultApp> Update(EventUpdateCommand command)
        //{
        //    ResultApp res = new ResultApp();
        //    try
        //    {
        //        ProfileDancer profile = _dbContext.ProfileDancer.FirstOrDefault(u => u.ProfileDanceId == command.ProfileDanceId);

        //        if (profile != null)
        //        {

        //            await this.command.Update<ProfileDancer>(UpdateEntity(profile, command));
        //            res.Succeeded = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.message = ex.Message;
        //    }

        //    return res;



        //}

        //public ProfileDancer UpdateEntity(Event entity, EventUpdateCommand comand_)
        //{
        //    profile.DanceRol_FK = comand_.DanceRol_FK != 0 ? comand_.DanceRol_FK : profile.DanceRol_FK;
        //    profile.DanceLevel_FK = comand_.DanceLevel_FK != 0 ? comand_.DanceLevel_FK : profile.DanceLevel_FK;
        //    profile.Height = comand_.Height.HasValue ? comand_.Height : profile.Height;
        //    return profile;
        //}

        public Event MapToEntity(EventCreateCommand command_)
        {
            Event entity = new Event();
            entity.UserIdCreator_FK = command_.UserIdCreator_FK;
            entity.Name = command_.Name;
            entity.Description= command_.Description;
            entity.Image = command_.Image ?? null;
            entity.DateInit = command_.DateInit;
            entity.DateFinish = command_.DateFinish;
            entity.EventStateId_fk = command_.EventStateId_fk;
            entity.TypeEventId_fk = command_.TypeEventId_fk;
            if (command_.Address != null)
            {
                Address Address_ = new Address();
                Address_.Street = command_.Address.Street;
                Address_.Number = command_.Address.Number;
                Address_.UserId_FK = command_.Address.UserId_FK;
                Address_.StateAddress = command_.Address.StateAddress;
                Address_.DetailAddress = command_.Address.DetailAddress;
                entity.Address = Address_;

                if (command_.Address.city != null)
                {
                    City city_ = new City();
                    city_.Name = command_.Address.city.Name;
                    entity.Address.City = city_;

                    if (command_.Address.city.Country_ != null)
                    {
                        Country country = new Country();
                        country.Name = command_.Address.city.Country_.Name;
                        entity.Address.City.Country = country;
                    }
                    else
                    {
                        entity.Address.CityId_FK = command_.Address.CityId_FK ?? 0;
                    }
                }
                else
                {
                    entity.Address.CityId_FK = command_.Address.CityId_FK ?? 0;
                }
            }
            else
            {
                entity.AddressId_fk = command_.AddressId_fk ?? 0;
            }
            


            return entity;
        }

        public Event MapToEntityOnlyFK(EventCreateCommand command_)
        {
            Event entity = new Event();
            entity.UserIdCreator_FK = command_.UserIdCreator_FK;
            entity.Name = command_.Name;
            entity.Description = command_.Description;
            entity.Image = command_.Image ?? null;
            entity.DateInit = command_.DateInit;
            entity.DateFinish = command_.DateFinish;
            entity.EventStateId_fk = command_.EventStateId_fk;
            entity.TypeEventId_fk = command_.TypeEventId_fk;
            if (command_.Address != null)
            {
                Address Address_ = new Address();
                Address_.Street = command_.Address.Street;
                Address_.Number = command_.Address.Number;
                Address_.UserId_FK = command_.Address.UserId_FK;
                Address_.StateAddress = command_.Address.StateAddress;
                Address_.DetailAddress = command_.Address.DetailAddress;
                Address_.CityId_FK = command_.Address.CityId_FK ?? 0;
                entity.Address = Address_;
            }
            else
            {
                entity.AddressId_fk = command_.AddressId_fk ?? 0;
            }
            return entity;
        }
        public Task<ResultApp<Event>> Update(EventUpdateCommand entity)
        {
            throw new NotImplementedException();
        }
    }
}

