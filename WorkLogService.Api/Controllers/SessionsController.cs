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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly WorkLogDbContext _context;

        // GET api/sessions
        [HttpGet]
        public ActionResult<IEnumerable<Session>> GetSessions()
        {
            return _context.Sessions;
        }

        // GET api/sessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var session = await _context.Sessions.FindAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        // POST api/sessions
        [HttpPost]
        public async Task<IActionResult> PostSession([FromBody] Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSession", new { id = session.Id }, session);
        }

        // PUT api/sessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession([FromRoute] int id, [FromBody] Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != session.Id)
            {
                return BadRequest();
            }

            _context.Entry(session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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

        // DELETE api/sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();

            return Ok(session);
        }

        private bool SessionExists(int id)
        {
            return _context.Sessions.Any(s => s.Id == id);
        }

        public SessionsController(WorkLogDbContext context)
        {
            _context = context;
        }
    }
}
