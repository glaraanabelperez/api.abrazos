using Abrazos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserQueryService _userService;
        //private readonly IUserCreateCommandHandler _userCreateHandler;

        public UserController(IUserQueryService IUserService
              //IUserCreateCommandHandler IUserCreatehandler
        )
        {
            _userService = IUserService;
            //_userCreateHandler = IUserCreatehandler;
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


    }
}