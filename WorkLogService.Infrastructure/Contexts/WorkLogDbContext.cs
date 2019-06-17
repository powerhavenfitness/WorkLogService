using Microsoft.EntityFrameworkCore;
using WorkLogService.Core.Models;

namespace WorkLogService.Infrastructure.Contexts
{
    public class WorkLogDbContext: DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        public DbSet<Set> Sets { get; set; }

        public WorkLogDbContext(DbContextOptions<WorkLogDbContext> options) : base(options)
        {

        }
    }
}