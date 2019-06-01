using System;
using System.Linq;
using WorkLogService.Interfaces.Core;
using WorkLogService.Interfaces.Infrastructure;

namespace WorkLogService.Core.Models
{
    public class Session : ISession
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
