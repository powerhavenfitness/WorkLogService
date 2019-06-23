using System;

namespace WorkLogService.Core.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}