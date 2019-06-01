using System;
using WorkLogService.Interfaces.Infrastructure;

namespace WorkLogService.Interfaces.Core
{
    public interface IWorkout
    {
        int Id { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }
    }
}
