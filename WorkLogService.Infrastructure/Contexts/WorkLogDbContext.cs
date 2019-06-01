using Microsoft.EntityFrameworkCore;
using WorkLogService.Interfaces.Infrastructure;
using WorkLogService.Interfaces.Core;

namespace WorkLogService.Infrastructure.Contexts
{
    public class WorkLogDbContext: DbContext, IContext
    {
        public DbSet<ISession> Sessions { get; set; }

        public DbSet<IWorkout> Workouts { get; set; }

        public WorkLogDbContext(DbContextOptions<WorkLogDbContext> options) : base(options)
        {

        }
    }
}
