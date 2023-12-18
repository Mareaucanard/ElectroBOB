using Microsoft.AspNetCore.Mvc;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Context;
using Eletro_BOB_API.Classes;

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
        public IActionResult Post(BasicUser user)
        {
            try
            {
                _context.Users.Find(1);
                return Ok("Token");
                /*Users temp = _context.Users.Where(u => u.Login == user.Login).FirstOrDefault();
                if (temp == null)
                {
                    return Unauthorized("Invalid login or password");
                }
                if (user.Password == temp.Password)
                {
                    return Ok("Token");
                }
                else
                {
                    return Unauthorized("Invalid login or password");
                }*/
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
