using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.Models
{
    public class DateAndName
    {
        public string nameOfVisitor { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string fromTime { get; set; }
        public string toTime { get; set; }
    }
}
