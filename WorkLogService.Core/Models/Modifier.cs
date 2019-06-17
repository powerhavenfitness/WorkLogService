namespace WorkLogService.Core.Models
{
    public class Modifier : BaseModel
    {
        public int VariableId { get; set; }
        public int WorkoutId { get; set; }
        public string Value { get; set; }
    }
}