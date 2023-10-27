using Abrazos.Persistence.Database;
using Abrazos.ServiceEventHandler.Commands;
using Abrazos.Services.Interfaces;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.AspNetCore.Mvc;



namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserCreateHandler _userCreateHandler;

        public RegisterController(
          ILogger<UserController> logger,
          IUserCreateHandler IUserCreatehandler
        )
        {
            _logger = logger;
            _userCreateHandler = IUserCreatehandler;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateCommand User)
        {
            var user = await _userCreateHandler.AddUser(User);

            _logger.LogWarning($"GatAsync  | User:  ");
            return Ok(user);

        }
    }
}