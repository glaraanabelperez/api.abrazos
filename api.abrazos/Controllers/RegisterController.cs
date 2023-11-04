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
        private readonly IUserCreateCommandHandler _userCreateHandler;

        public RegisterController(
          IUserCreateCommandHandler IUserCreatehandler
        )
        {
            _userCreateHandler = IUserCreatehandler;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateCommand User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userCreateHandler.AddUser(User);
            return result?.Succeeded ?? false
                    ? Ok(result)
                    : BadRequest(result?.message);

        }
    }
}