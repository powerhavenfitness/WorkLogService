using WorkLogService.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkLogService.Infrastructure.Contexts
{
    public class WorkLogDbContext: DbContext
    {
        public DbSet<Session> Sessions { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public WorkLogDbContext(DbContextOptions<WorkLogDbContext> options) : base(options)
        {

        }
    }
}
