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
        private readonly IProfileDancerQueryService _profile;
        //private readonly IUserCommandHandler _userCommandHandler;

        public ProfileDancerController(IProfileDancerQueryService profile)
        {
            _profile = profile;
        }

        [HttpGet("{profileId}")]
        public async Task<IActionResult> GetAsync(int profileId)
        {
            var user = await _profile.GatAsync(profileId);

            return Ok(user);

        }

        ///// <summary>
        ///// Return All Users by some filters.
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="take"></param>
        ///// <param name="name"></param>
        ///// <param name="userName"></param>
        ///// <param name="userStates"></param>
        ///// <param name="danceLevel"></param>
        ///// <param name="danceRol"></param>
        ///// <param name="evenType"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> GetAll(
        //    int page = 1,
        //    int take = 500,
        //    string? name = null,
        //    string? userName = null,
        //    bool? userStates = null,
        //    int? danceLevel = null,
        //    int? danceRol = null,
        //    int? evenType = null
        //)
        //{

        //    var users = await _userService.GetAllAsync(
        //      page,
        //      take,
        //      name,
        //      userName,
        //      userStates,
        //      danceLevel,
        //      danceRol,
        //      evenType
        //       );

        //    return Ok(users);
        //}

        //[HttpPut]
        ////[Route("/updateUser")]
        //public async Task<IActionResult> UpdateUser(UserUpdateCommand User)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _userCommandHandler.UpdateUser(User);
        //    return result?.Succeeded ?? false
        //            ? Ok(result)
        //            : BadRequest(result?.message);

        //}

    }
}