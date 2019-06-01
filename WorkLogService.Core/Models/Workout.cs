using System;
using System.Linq;
using WorkLogService.Core.Enums;
using WorkLogService.Interfaces.Core;
using WorkLogService.Interfaces.Infrastructure;

namespace WorkLogService.Core.Models
{
    public class Workout : IWorkout
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public EExercise Exercise { get; set; }

        public int Sets { get; set; }

        public int Reps { get; set; }

        public double Load { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
