using System;
using System.Collections.Generic;

namespace DALCore.Models
{
    public partial class EmployeeLogs
    {
        public int LogId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfVisit { get; set; }
        public TimeSpan TimeOfEntry { get; set; }
        public DateTime DateOfExit { get; set; }
        public TimeSpan TimeOfExit { get; set; }
    }
}
