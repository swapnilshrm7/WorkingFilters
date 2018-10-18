using System;
using System.Collections.Generic;

namespace DALCore.Models
{
    public partial class Employees
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmailId { get; set; }
        public string Location { get; set; }
        public string EmployeeStatus { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LocalAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string EmergencyContactPerson { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string SecondaryContactNumber { get; set; }
        public DateTime DateOfJoining { get; set; }
        public DateTime? DateOfResignation { get; set; }
        public string Remark { get; set; }
        public string BloodGroup { get; set; }
        public string MedicalSpecification { get; set; }
    }
}
