using Microsoft.AspNetCore.Mvc;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Context;
using Eletro_BOB_API.Classes;
using Microsoft.EntityFrameworkCore;

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
                Users newUser = new Users();
                newUser.Login = user.Login;
                newUser.Password = user.Password;
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                Preference newPref = new Preference();
                newPref.ActiveNotifications = true;
                newPref.ActiveSMS = true;
                newPref.ActiveEmail = true;
                Users temp = await _context.Users.Where(u => u.Login == user.Login).FirstOrDefaultAsync();
                newPref.UserId = temp.Id;
                await _context.Preferences.AddAsync(newPref);
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
