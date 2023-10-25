using Abrazos.Persistence.Database;
using Abrazos.ServiceEventHandler.Commands;
using Abrazos.Services.Interfaces;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public AbrazosDbContext _db;
        private readonly ILogger<UserController> _logger;
        private readonly IUserQueryService _userService;
        private readonly IUserCreateHandler _userCreateHandler;

        public UserController(
          ILogger<UserController> logger,
          AbrazosDbContext dbcontext,
          IUserQueryService IUserService,
          IUserCreateHandler IUserCreatehandler
        )
        {
            _logger = logger;
            _db = dbcontext;
            _userService = IUserService;
            _userCreateHandler = IUserCreatehandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GatAsync(userId);

            _logger.LogWarning($"GatAsync  | user:  ");
            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateCommand User)
        {      
            var user =  _userCreateHandler.AddUser(User);

            //_logger.LogWarning($"GatAsync  | user:  ");
            return Ok(user);

        }
    }
}