using System;

namespace WorkLogService.Core.Models
{
    public class Set
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int Reps { get; set; }
        public double Load { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}