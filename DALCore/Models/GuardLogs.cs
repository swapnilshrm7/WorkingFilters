using System;
using System.Collections.Generic;

namespace DALCore.Models
{
    public partial class GuardLogs
    {
        public int SerialNumber { get; set; }
        public string GuardId { get; set; }
        public string GuardPassword { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}
