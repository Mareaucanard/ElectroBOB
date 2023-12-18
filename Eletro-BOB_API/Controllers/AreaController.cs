using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eletro_BOB_API.Models;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            // get all Area of the id of the user
            return Ok("ok");
        }

        [HttpPost]
        public IActionResult Post(Area area)
        {
            // create the new area in DB
            return Ok("Succesfuly created");
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Area area)
        {
            // update the area in DB
            return Ok("Succesfuly updated");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // delete the area in DB
            return Ok("Succesfuly deleted");
        }
    }
}
