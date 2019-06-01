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
    public class WorkoutsController : ControllerBase
    {
        private readonly WorkLogDbContext _context;

        // GET api/Workouts
        [HttpGet]
        public ActionResult<IEnumerable<Workout>> GetWorkouts()
        {
            return _context.Workouts;
        }

        // GET api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetWorkout([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workout = await _context.Workouts.FindAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        // POST api/Workouts
        [HttpPost]
        public async Task<IActionResult> PostWorkout([FromBody] Workout Workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Workouts.Add(Workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkout", new { id = Workout.Id }, Workout);
        }

        // PUT api/Workouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout([FromRoute] int id, [FromBody] Workout Workout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Workout.Id)
            {
                return BadRequest();
            }

            _context.Entry(Workout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutExists(id))
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

        // DELETE api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return Ok(workout);
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workouts.Any(w => w.Id == id);
        }

        public WorkoutsController(WorkLogDbContext context)
        {
            _context = context;
        }
    }
}
