using Abrazos.ServiceEventHandler;
using Abrazos.Services.Interfaces;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceEventHandler.Command.CreateCommand;

namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("v1/event")]
    //[Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventCommandHandler command_;

        public EventController(IEventCommandHandler command)
        {
            command_ = command;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(EventCreateCommand commandCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await command_.Add(commandCreate);
            return result?.Succeeded ?? false
                    ? Ok(result)
                    : BadRequest(result?.message);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ProfileDancerUpdateCommand profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return null;
            //var result = await command_.Update(profile);
            //return result?.Succeeded ?? false
            //        ? Ok(result)
            //        : BadRequest(result?.message);

        }

    }
}