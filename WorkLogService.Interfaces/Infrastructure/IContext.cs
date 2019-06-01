using Microsoft.EntityFrameworkCore;
using WorkLogService.Interfaces.Core;

namespace WorkLogService.Interfaces.Infrastructure
{
    public interface IContext
    {
        DbSet<ISession> Sessions { get; set; }

        DbSet<IWorkout> Workouts { get; set; }
    }
}
