using Abrazos.Services.Interfaces;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userService;
        private readonly IUserCommandHandler _userCommandHandler;

        public UserController(IUserQueryService IUserService,IUserCommandHandler userCommandHandler)
        {
            _userService = IUserService;
            _userCommandHandler = userCommandHandler;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GatAsync(userId);

            return Ok(user);

        }

        /// <summary>
        /// Return All Users by some filters.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <param name="name"></param>
        /// <param name="userName"></param>
        /// <param name="userStates"></param>
        /// <param name="danceLevel"></param>
        /// <param name="danceRol"></param>
        /// <param name="evenType"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(
            int page = 1,
            int take = 500,
            string? name = null,
            string? userName = null,
            bool? userStates = null,
            int? danceLevel = null,
            int? danceRol = null,
            int? evenType = null
        )
        {

            var users = await _userService.GetAllAsync(
              page,
              take,
              name,
              userName,
              userStates,
              danceLevel,
              danceRol,
              evenType
               );

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateCommand User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userCommandHandler.AddUser(User);
            return result?.Succeeded ?? false
                    ? Ok(result)
                    : BadRequest(result?.message);

        }

    }
}