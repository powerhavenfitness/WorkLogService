using WorkLogService.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkLogService.Contexts
{
    public class WorkLogDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public WorkLogDbContext(DbContextOptions<WorkLogDbContext> options) : base(options)
        {

        }
    }
}
