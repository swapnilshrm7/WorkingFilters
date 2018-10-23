using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.Models
{
    public class IdAndOtp
    {
        public string UserId { get; set; }
        public int Otp { get; set; }
    }
}
