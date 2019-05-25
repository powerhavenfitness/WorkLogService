using System;

namespace WorkLogService.Models
{
    public class Session
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
