using Abrazos.Persistence.Database;
using Abrazos.Services.Interfaces;
using Abrazos.ServicesEvenetHandler.Intefaces;
using Microsoft.AspNetCore.Mvc;
using ServiceEventHandler.Command;
using ServiceEventHandler.Command.CreateCommand;
using Utils;

namespace api.abrazos.Controllers
{
    [ApiController]
    [Route("v1/register")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserCommandHandler _userCommandHandler;

        public RegisterController(
          IUserCommandHandler IUserCreatehandler
        )
        {
            _userCommandHandler = IUserCreatehandler;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateCommand User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var  result = await _userCommandHandler.AddUser(User);
            return result?.Succeeded ?? false
                    ? Ok(result)
                    : BadRequest(result?.message);//devolver mensaje bien

        }
    }
}