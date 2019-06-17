using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WorkLogService.Core.Models;
using WorkLogService.Infrastructure.Contexts;

namespace WorkLogService.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModifiersController : ControllerBase
    {
        private readonly WorkLogDbContext _context;

        public ModifiersController(WorkLogDbContext context)
        {
            _context = context;
        }

        // GET: api/Modifiers
        [HttpGet]
        public IEnumerable<Modifier> GetModifiers()
        {
            return _context.Modifiers;
        }

        // GET: api/Modifiers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModifier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modifier = await _context.Modifiers.FindAsync(id);

            if (modifier == null)
            {
                return NotFound();
            }

            return Ok(modifier);
        }

        // PUT: api/Modifiers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModifier([FromRoute] int id, [FromBody] Modifier modifier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modifier.Id)
            {
                return BadRequest();
            }

            modifier.SetDateUpated();

            _context.Entry(modifier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModifierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Modifiers
        [HttpPost]
        public async Task<IActionResult> PostModifier([FromBody] Modifier modifier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            modifier.SetDateCreated();

            _context.Modifiers.Add(modifier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModifier", new { id = modifier.Id }, modifier);
        }

        // DELETE: api/Modifiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModifier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var modifier = await _context.Modifiers.FindAsync(id);
            if (modifier == null)
            {
                return NotFound();
            }

            _context.Modifiers.Remove(modifier);
            await _context.SaveChangesAsync();

            return Ok(modifier);
        }

        private bool ModifierExists(int id)
        {
            return _context.Modifiers.Any(e => e.Id == id);
        }
    }
}