using System;

namespace WorkLogService.Models
{
    public class Workout
    {
        public int Id { get; set; }

        public int SessionId { get; set; }

        public int ExerciseId { get; set; }

        public int Sets { get; set; }

        public int Repos { get; set; }

        public double Load { get; set; }

        public DateTime DateAdded { get { return DateTime.Now; } set { } }
    }
}
