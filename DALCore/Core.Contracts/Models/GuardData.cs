using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public class GuardData
    {
        public string GuardId { get; set; }
        public string GuardName { get; set; }
        public string EmailId { get; set; }
        public string GuardStatus { get; set; }
        public string Gender { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string MedicalSpecification { get; set; }
        public int SerialNumber { get; set; } 
        public TimeSpan LoginTime { get; set; }
        public TimeSpan LogoutTime { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }

    }
}
