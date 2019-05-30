using System;

namespace WorkLogService.Core.Models
{
    public class Session
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
