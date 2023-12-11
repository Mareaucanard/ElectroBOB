using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string[] reactionList = new string[] { "Discord:Send a message", "Discord:Add reaction to message", "Whatsapp:Send message in group" };
            return Ok(reactionList);
        }
    }
}
