using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Context;
using Microsoft.EntityFrameworkCore;
using Eletro_BOB_API.Classes;
using Microsoft.EntityFrameworkCore.Storage;

namespace Eletro_BOB_API.Controllers
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly AreaContext _context;
        public AreaController(AreaContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                List<Area> actions = await _context.Areas.Where(a => a.UsersId == id).ToListAsync();
                return Ok(actions);
            }
            catch (Exception e)
            {
                return BadRequest("Echec de la récupération des area");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AreaBasic area)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Area temp = new Area();
                    temp.Name = area.Name;
                    temp.Description = area.Description;
                    temp.IsActive = area.IsActive;
                    temp.UsersId = area.UsersId;
                    await _context.Areas.AddAsync(temp);
                    await _context.SaveChangesAsync();
                    ActionTrigger action = new ActionTrigger();
                    action.AreaId = temp.Id;
                    action.Name = area.action.Name;
                    action.nbMin = area.action.nbMin;
                    action.NextTrigger = DateTime.Now;
                    action.NextTrigger = action.NextTrigger.AddMinutes(action.nbMin);
                    await _context.ActionTriggers.AddAsync(action);
                    await _context.SaveChangesAsync();
                    foreach (ReactionBasic reaction in area.reactions)
                    {
                        ReactionTrigger reactionTrigger = new ReactionTrigger();
                        reactionTrigger.Name = reaction.Name;
                        reactionTrigger.From = reaction.From;
                        reactionTrigger.To = reaction.To;
                        reactionTrigger.Message = reaction.Message;
                        reactionTrigger.AreaId = temp.Id;
                        await _context.ReactionTriggers.AddAsync(reactionTrigger);
                        await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                    return Ok("Area succesfuly created");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest("Echec de la creation de l'area");
                }
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, AreaBasic area)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var current = await _context.Areas.FindAsync(id);
                    current.Name = area.Name;
                    current.Description = area.Description;
                    current.IsActive = area.IsActive;
                    current.UsersId = area.UsersId;
                    _context.Areas.Update(current);
                    await _context.SaveChangesAsync();
                    var action = await _context.ActionTriggers.Where(a => a.Id == area.action.Id).FirstOrDefaultAsync();
                    action.Name = area.action.Name;
                    action.nbMin = area.action.nbMin;
                    _context.ActionTriggers.Update(action);
                    await _context.SaveChangesAsync();
                    foreach (ReactionBasic reaction in area.reactions)
                    {
                        var temp = await _context.ReactionTriggers.Where(r => r.Id == reaction.Id).FirstOrDefaultAsync();
                        temp.Name = reaction.Name;
                        temp.From = reaction.From;
                        temp.To = reaction.To;
                        temp.Message = reaction.Message;
                        _context.ReactionTriggers.Update(temp);
                        await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                    return Ok("Area succesfuly updated");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest("Echec de la modifications de l'area");
                }
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Area area = await _context.Areas.FindAsync(id);
                ActionTrigger action = await _context.ActionTriggers.Where(r => r.Id == id).FirstOrDefaultAsync();
                List<ReactionTrigger> reactions = await _context.ReactionTriggers.Where(r => r.AreaId == id).ToListAsync();
                _context.ReactionTriggers.RemoveRange(reactions);
                _context.ActionTriggers.Remove(action);
                _context.Areas.Remove(area);
                await _context.SaveChangesAsync();
                return Ok("Area succesfuly deleted");
            }
            catch (Exception e)
            {
                return BadRequest("Echec de la suppression de l'area");
            }
        }
    }
}
