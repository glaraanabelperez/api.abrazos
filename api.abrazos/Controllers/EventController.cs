using Abrazos.ServiceEventHandler;
using Abrazos.Services.Interfaces;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceEventHandler.Command.CreateCommand;
using ServiceEventHandler.Command.UpdateCommand;
using System.Net.NetworkInformation;

namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("v1/event")]
    //[Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventCommandService command_;
        private readonly IEventQueryService _eventQuery;

        public EventController(IEventCommandService command, IEventQueryService eventQuery)
        {
            command_ = command;
            _eventQuery = eventQuery;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(EventCreateCommand commandCreate)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await command_.AddRange(commandCreate);
            return result?.Succeeded ?? false
                    ? Ok(result)
                    : BadRequest(result?.message);

        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(EventUpdateCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await command_.Update(command);
            return result?.Succeeded ?? false
                    ? Ok(result)
                    : BadRequest(result?.message);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <param name="organizerId"></param>
        /// <param name="CycleId"></param>
        /// <param name="danceLevel"></param>
        /// <param name="danceRol"></param>
        /// <param name="evenType"></param>
        /// <param name="CityId"></param>
        /// <param name="addressId"></param>
        /// <param name="countryId"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateFinish"></param>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(
            string? search,
            int? organizerId,
            int? CycleId,
            int? danceLevel,
            int? danceRol,
            int? evenType,
            int? CityId,
            int? addressId,
            string? countryId,
            DateTime? dateCreated,
            DateTime? dateFinish,
            int page = 1,
            int take = 500
        )
        {
            var events = await _eventQuery.GetAllAsync(
                search,
                organizerId,
                CycleId,
                danceLevel,
                danceRol,
                evenType,
                CityId,
                addressId,
                countryId,
                dateCreated,
                dateFinish,
                page,
                take
               );

            return Ok(events);
        }


        /// <summary>
        /// Return Evenet by Id.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetAsync(int eventId)
        {
            var event_ = await _eventQuery.GetAsync(eventId);

            return event_ != null
            ? Ok(event_)
            : StatusCode(204);

        }

    }
}