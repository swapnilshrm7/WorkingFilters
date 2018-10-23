using System;
using System.Collections.Generic;

namespace DALCore.Models
{
    public partial class LoginCredentials
    {
        public int SerialNumber { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Category { get; set; }
        public string ContactNo { get; set; }
        public int Otp { get; set; }
    }
}
