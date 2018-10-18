using System;
using System.Collections.Generic;

namespace DALCore.Models
{
    public partial class Visitors
    {
        public int VisitorId { get; set; }
        public string NameOfVisitor { get; set; }
        public string Contact { get; set; }
        public string VisitorImage { get; set; }
        public string GovtIdProof { get; set; }
    }
}
