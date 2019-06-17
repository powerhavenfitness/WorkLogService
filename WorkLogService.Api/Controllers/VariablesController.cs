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
    public class VariablesController : ControllerBase
    {
        private readonly WorkLogDbContext _context;

        public VariablesController(WorkLogDbContext context)
        {
            _context = context;
        }

        // GET: api/Variables
        [HttpGet]
        public IEnumerable<Variable> GetVariables()
        {
            return _context.Variables;
        }

        // GET: api/Variables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVariable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var variable = await _context.Variables.FindAsync(id);

            if (variable == null)
            {
                return NotFound();
            }

            return Ok(variable);
        }

        // PUT: api/Variables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariable([FromRoute] int id, [FromBody] Variable variable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != variable.Id)
            {
                return BadRequest();
            }

            variable.SetDateUpated();

            _context.Entry(variable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariableExists(id))
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

        // POST: api/Variables
        [HttpPost]
        public async Task<IActionResult> PostVariable([FromBody] Variable variable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            variable.SetDateCreated();

            _context.Variables.Add(variable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariable", new { id = variable.Id }, variable);
        }

        // DELETE: api/Variables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var variable = await _context.Variables.FindAsync(id);
            if (variable == null)
            {
                return NotFound();
            }

            _context.Variables.Remove(variable);
            await _context.SaveChangesAsync();

            return Ok(variable);
        }

        private bool VariableExists(int id)
        {
            return _context.Variables.Any(e => e.Id == id);
        }
    }
}