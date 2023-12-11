using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string[] actionList = new string[] { "Discord:Receive a message", "Discord:message in groupe", "Whatsapp:Message in group" };
            return Ok(actionList);
        }
    }
}
