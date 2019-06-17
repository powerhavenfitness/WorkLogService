namespace WorkLogService.Core.Models
{
    public class Set : BaseModel
    {
        public int WorkoutId { get; set; }
        public int Reps { get; set; }
        public double Load { get; set; }
    }
}