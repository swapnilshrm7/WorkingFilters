using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.Models
{
    public class AllLogs
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public string ContactNo { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public DateTime IndateInTime { get; set; }
    }
}