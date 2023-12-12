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
            Preference[] preferenceList = { new Preference(1, true, true, false), new Preference(2, false, true, false) };
            return Ok(preferenceList.Where(test => test.Id == 1));
        }
    }
}
