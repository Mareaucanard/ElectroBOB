using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eletro_BOB_API.Models;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnexionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            if (user.Login == "admin" && user.Password == "admin")
            {
                return Ok("Token");
            }
            else
            {
                return Unauthorized("Invalid login or password");
            }
        }
    }
}
