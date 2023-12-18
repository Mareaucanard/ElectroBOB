using Microsoft.AspNetCore.Mvc;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Context;
using Eletro_BOB_API.Classes;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AreaContext _context;
        public RegisterController(AreaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BasicUser user)
        {
            try
            {
                /*Users newUser = new Users();
                newUser.Login = user.Login;
                newUser.Password = user.Password;
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return Ok("User created succesfuly");*/
                if (_context == null)
                {
                    return BadRequest("Context is null");
                }
                ActionTrigger action = new ActionTrigger();
                action.Name = "Test";
                action.Url = "Test";
                await _context.Actions.AddAsync(action);
                await _context.SaveChangesAsync();
                return Ok("User created succesfuly");
            }
            catch (System.Exception)
            {
                return BadRequest("Error when creating user");
            }
        }
    }
}
