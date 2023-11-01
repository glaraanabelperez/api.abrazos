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
        private readonly IUserQueryService _userService;
        //private readonly IUserCreateCommandHandler _userCreateHandler;

        public UserController(
              IUserQueryService IUserService
              //IUserCreateCommandHandler IUserCreatehandler
        )
        {
            _userService = IUserService;
            //_userCreateHandler = IUserCreatehandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int userId)
        {
            //var user = await _userService.GatAsync(userId);

            return null;

        }

        
    }
}