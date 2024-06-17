

using Abrazos.Persistence.Database;
using Abrazos.ServicesEvenetHandler.Intefaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Models;
using ServiceEventHandler.Command.CreateCommand;
using ServiceEventHandler.Command.UpdateCommand;
using ServiceEventHandler.Validators;
using ServicesQueries.Dto;
using Utils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Abrazos.ServiceEventHandler
{
    public class EventCommandService: IEventCommandService
    {
        private readonly ILogger<EventCommandService> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public IGenericRepository commandGeneric;

        public EventCommandService(ApplicationDbContext dbContext, IGenericRepository command, 
            ILogger<EventCommandService> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            this.commandGeneric = command;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResultApp> AddRange(EventCreateCommand command)
        {
            // AddRange is not in Generci Repository. Is Necesary use try catch and transac here.
            ResultApp res = new ResultApp();

            _dbContext.AddRange(MapToEntity(command));
            _dbContext.SaveChanges();
            res.Succeeded = true;
            return res;

        }
        public ICollection<Event> MapToEntity(EventCreateCommand command_)
        {
            ICollection<Event> Eventos = new List<Event>();

            foreach(var e in command_.dateTimes)
            {
                Event entity = new Event();
                entity.UserIdCreator = command_.UserIdCreator;
                entity.Name = command_.Name;
                entity.Description = command_.Description;
                entity.Image = command_.Image ?? null;
                entity.DateInit = e.dateInit;
                entity.DateFinish = e.dateFinish;
                entity.EventStateId = command_.EventStateId;
                entity.TypeEventId = command_.TypeEventId;
                entity.LevelId = command_.LevelId != null ? command_.LevelId : null;
                entity.RolId = command_.RolId != null ? command_.LevelId : null;
                entity.Couple = command_.Couple;
                entity.Cupo = command_.Cupo ?? null;

                if (!Validations.IdOrObjectMandatory(command_.AddressId, command_.Address))
                {
                    throw new Exception("Hubo un problema en la direccion. Asegurese de mandar, el AddresId ó la nueva direccion a ingresar");
                }

                entity.AddressId = command_.AddressId ?? 0;
                if (command_.Address != null)
                {
                    Address Address_ = new Address();
                    Address_.Street = command_.Address.Street;
                    Address_.Number = command_.Address.Number;
                    Address_.UserId = command_.UserIdCreator;
                    Address_.StateAddress = true;
                    Address_.DetailAddress = command_.Address.DetailAddress;
                    Address_.VenueName = command_.Address.VenueName?? null;
                    Address_.CityId = command_.Address.CityId;

                    entity.Address = Address_;
                }
 
                Cycle cicle = new Cycle();
                cicle.CycleTitle = command_.Name;
                cicle.Description = command_.Description;
                entity.Cycle = cicle;
                Eventos.Add(entity);
            }

            return Eventos;
        }

        /// <summary>
        /// Send the entity tu Perository's Generic to update.
        /// </summary>
        /// <param name="command_"></param>
        /// <returns></returns>
        public async Task<ResultApp> Update(EventUpdateCommand command_)
        {
            ResultApp res = new ResultApp();
 
            var resEntity = await this.commandGeneric.Update<Event>(MapToEntityUpdate(command_));
            res.Succeeded = true;
 
            return res;
        }
        public  Event MapToEntityUpdate(EventUpdateCommand command_)
        {
            var entity =  _dbContext.Event
                                     .SingleOrDefault(x => x.EventId == command_.EventId);

            entity.EventId=command_.EventId;
            entity.UserIdCreator = command_.UserIdCreator??entity.UserIdCreator;
            entity.Name = command_.Name?? entity.Name;
            entity.Description = command_.Description?? entity.Description;
            entity.DateInit = command_.dateTimes.dateInit?? entity.DateInit;
            entity.DateFinish = command_.dateTimes.dateFinish ?? entity.DateFinish;
            entity.EventStateId = command_.EventStateId ?? entity.EventStateId;
            entity.TypeEventId = command_.TypeEventId ?? entity.TypeEventId;
            entity.LevelId = command_.LevelId ?? entity.LevelId;
            entity.RolId = command_.RolId ?? entity.RolId ;
            entity.Couple = command_.Couple ?? entity.Couple;
            entity.Cupo = command_.Cupo ?? entity.Cupo;
            entity.AddressId = command_.AddressId ?? entity.AddressId;
            entity.CycleId = command_.CycleId ?? entity.CycleId;
                

                return entity;
        }

     
    }
}

