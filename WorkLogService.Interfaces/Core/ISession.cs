using System;
using WorkLogService.Interfaces.Infrastructure;

namespace WorkLogService.Interfaces.Core
{
    public interface ISession
    {
        int Id { get; set; }

        DateTime DateCreated { get; set; }

        DateTime DateUpdated { get; set; }
    }
}
