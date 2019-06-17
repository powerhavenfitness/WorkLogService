using System;

namespace WorkLogService.Core.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public void SetDateCreated()
        {
            var date = DateTime.Now;

            DateCreated = date;
            DateUpdated = date;
        }

        public void SetDateUpated()
        {
            var date = DateTime.Now;

            DateUpdated = date;
        }
    }
}