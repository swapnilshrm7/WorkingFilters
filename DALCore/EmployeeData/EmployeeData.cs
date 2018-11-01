using System;

namespace UI.Entities
{
    public class EmployeeData
    {
        public int LogId { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfVisit { get; set; }
        public TimeSpan TimeOfEntry { get; set; }
        public DateTime DateOfExit { get; set; }
        public TimeSpan TimeOfExit { get; set; }
        public bool Error { get; set; }
    }
}
