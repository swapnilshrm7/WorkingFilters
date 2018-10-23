using System;
using System.Collections.Generic;

namespace DALCore.Models
{
    public partial class VisitorsLogs
    {
        public int LogId { get; set; }
        public string ComingFrom { get; set; }
        public string WhomToMeet { get; set; }
        public string EmployeeId { get; set; }
        public DateTime DateOfVisit { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public int VisitorId { get; set; }
        public string GuardId { get; set; }
        public string PurposeOfVisit { get; set; }
    }
}
