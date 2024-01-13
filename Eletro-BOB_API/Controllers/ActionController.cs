using Eletro_BOB_API.Context;
using Eletro_BOB_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly AreaContext _context;
        public ActionController(AreaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ActionCatalog> actions = await _context.ActionCatalogs.ToListAsync();
                return Ok(actions);
            }
            catch (Exception e)
            {
                return BadRequest("Echec de récupération des actions");
            }
        }
    }
}
