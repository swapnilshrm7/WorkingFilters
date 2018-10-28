using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public class VisitorsData
    {
        public string NameOfVisitor { get; set; }
        public string GovtIdProof { get; set; }
        public string Contact { get; set; }
        public string ComingFrom { get; set; }
        public string WhomToMeet { get; set; }
        public string DateOfVisit { get; set; }
        public string EmployeeId { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public int VisitorId { get; set; }
        public string GuardId { get; set; }
    }
}
