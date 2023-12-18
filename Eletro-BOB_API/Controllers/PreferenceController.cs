using Eletro_BOB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // get all preferences of the user
            return Ok("ok");
        }
    }
}
