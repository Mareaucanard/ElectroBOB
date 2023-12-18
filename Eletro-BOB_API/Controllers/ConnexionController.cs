using Microsoft.AspNetCore.Mvc;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Context;
using Eletro_BOB_API.Classes;
using Microsoft.EntityFrameworkCore;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnexionController : ControllerBase
    {
        private readonly AreaContext _context;
        public ConnexionController(AreaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BasicUser user)
        {
            try
            {
                Users temp = await _context.Users.Where(u => u.Login == user.Login).FirstOrDefaultAsync();
                if (temp != null && user.Password == temp.Password)
                {
                    return Ok("Token");
                }
                else
                    return Unauthorized("Invalid login or password");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
