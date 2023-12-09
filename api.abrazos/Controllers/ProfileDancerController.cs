using Abrazos.ServiceEventHandler;
using Abrazos.Services.Interfaces;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceEventHandler.Command.CreateCommand;

namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("v1/profileDancer")]
    //[Authorize]
    public class ProfileDancerController : ControllerBase
    {
        private readonly IProfileDancerCommandHandler _profile;

        public ProfileDancerController(IProfileDancerCommandHandler profile)
        {
            _profile = profile;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProfileDancerCreateCommand profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _profile.Add(profile);
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

            var result = await _profile.Update(profile);
            return result?.Succeeded ?? false
                    ? Ok(result)
                    : BadRequest(result?.message);

        }

    }
}