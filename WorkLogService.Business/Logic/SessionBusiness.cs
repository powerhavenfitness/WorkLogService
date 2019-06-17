using System;
using System.Collections.Generic;
using System.Text;
using WorkLogService.Core.Models;
using WorkLogService.Business.Objects;
using WorkLogService.Infrastructure.Contexts;

namespace WorkLogService.Business.Logic
{
    public class SessionBusiness
    {
        private readonly WorkLogDbContext _context;

        public BusinessResult GetAllSessions()
        {
            var result = new BusinessResult
            {

            };

            return result;
        }
    }
}