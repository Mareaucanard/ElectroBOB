using Eletro_BOB_API.Context;
using Eletro_BOB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly AreaContext _context;
        public ReactionController(AreaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ReactionCatalog> reactions = await _context.ReactionCatalogs.ToListAsync();
                return Ok(reactions);
            }
            catch (Exception ex)
            {
                return BadRequest("Counld get reactions");
            }
        }
    }
}
