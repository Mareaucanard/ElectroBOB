using Eletro_BOB_API.Context;
using Eletro_BOB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class PreferenceController : ControllerBase
    {
        private readonly AreaContext _context;
        public PreferenceController(AreaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Preference> preferences = await _context.Preferences.ToListAsync();
                return Ok("ok");
            }
            catch (Exception e)
            {
                return BadRequest("Error when getting preferences");
            }
        }
    }
}
