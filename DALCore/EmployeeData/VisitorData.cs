using System;
using System.Collections.Generic;
using System.Text;

namespace UI.Entities
{
    public class VisitorData
    {
        public int VisitorId { get; set; }
        public string NameOfVisitor { get; set; }
        public string Contact { get; set; }
        public string VisitorImage { get; set; }
        public string GovtIdProof { get; set; }
        public bool Error { get; set; }
    }
}
