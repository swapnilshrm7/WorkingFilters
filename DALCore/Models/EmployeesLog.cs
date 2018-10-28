using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.Models
{
    public class EmployeesLog
    {
        public int LogId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; } 
        public DateTime DateOfVisit { get; set; }
        public TimeSpan TimeOfEntry { get; set; }
    }
}
