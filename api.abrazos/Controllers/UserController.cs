using Abrazos.Persistence.Database;
using Abrazos.Services.Dto;
using Abrazos.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        public AbrazosDbContext _db;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;

        public UserController(ILogger<UserController> logger, AbrazosDbContext dbcontext, IUserService IUserService)
        {
            _logger = logger;
            _db = dbcontext;
            userService = IUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await userService.GatAsync(userId);

            _logger.LogWarning($"GatAsync  | user:  ");
            return Ok(user);

        }
    }
}