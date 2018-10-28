using System;
using System.Collections.Generic;

namespace DALCore.Models
{
    public partial class GuardLogs
    {
        public int SerialNumber { get; set; }
        public string GuardId { get; set; }
        public string GuardPassword { get; set; }
        public TimeSpan LoginTime { get; set; }
        public TimeSpan? LogoutTime { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime? LogoutDate { get; set; }
    }
}
