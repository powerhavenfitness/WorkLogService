using System;

namespace WorkLogService.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateAdded { get { return DateTime.Now; } set { } }
    }
}
