namespace WorkLogService.Core.Models
{
    public class Workout : BaseModel
    {
        public int SessionId { get; set; }
        public int ExerciseId { get; set; }
    }
}