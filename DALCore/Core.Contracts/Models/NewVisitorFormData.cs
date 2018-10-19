using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.Models
{
    public class NewVisitorFormData
    {
        public string nameOfVisitor { get; set; }
        public string contactNo { get; set; }
        public string govtIdProof { get; set; }
        public string comingFrom { get; set; }
        public string whomToMeet { get; set; }
        public string purposeOfVisit { get; set; }
        public string guardId { get; set; }
    }
}
