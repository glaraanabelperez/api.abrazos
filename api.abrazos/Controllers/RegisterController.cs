using Abrazos.Persistence.Database;
using Abrazos.ServiceEventHandler.Commands;
using Abrazos.Services.Dto;
using Abrazos.Services.Interfaces;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        public AbrazosDbContext _db;
        private readonly ILogger<UserController> _logger;
        private readonly IGenericRepository userService;

        public RegisterController(ILogger<UserController> logger, AbrazosDbContext dbcontext, IGenericRepository IUserEventHandler)
        {
            _logger = logger;
            _db = dbcontext;
            userService = IUserEventHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(UserCreateCommand userAdd)
        {
            userService.Add(userAdd);

            _logger.LogWarning($"GatAsync  | user:  ");
            return Ok();

        }
    }
}