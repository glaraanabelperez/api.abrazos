using Abrazos.Services.Interfaces;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.AspNetCore.Mvc;
using ServiceEventHandler.Command.CreateCommand;

namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("v1/profileDancer")]
    //[Authorize]
    public class ProfileDancerController : ControllerBase
    {
        private readonly IProfileDancerCommandService _queryCommand;
        private readonly IProfileDancerQueryService _queryService;


        public ProfileDancerController(IProfileDancerCommandService queryCommand, IProfileDancerQueryService queryService)
        {
            _queryCommand = queryCommand;
            _queryService = queryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProfileDancerCreateCommand profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _queryCommand.Add(profile);
            return result?.Succeeded ?? false
                    ? Ok(result)
                    : BadRequest(result);

        }

        [HttpPatch]
        public async Task<IActionResult> UpdateAsync(ProfileDancerUpdateCommand profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _queryCommand.Update(profile);
            return result?.Succeeded ?? false
                    ? Ok(result)
                    : BadRequest(result?.message);

        }


        /// <summary>
        /// Return Profile by Id. 
        ///     (The app show all users, by city for example, and then on click in one user, the app will shor the profile-)
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet("{profileId}")]
        public async Task<IActionResult> GetAsync(int profileId)
        {

            var event_ = await _queryService.GatAsync(profileId);
            return event_ != null
            ? Ok(event_)
            : StatusCode(204);

        }
        /// <summary>
        /// Delete profile by Id.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpDelete("{profileId}")]
        public async Task<IActionResult> DeleteAsync(int profileId)
        {

            var event_ = await _queryCommand.DeleteAsync(profileId);
            return event_ != null
            ? Ok(event_)
            : StatusCode(204);

        }
    }
}