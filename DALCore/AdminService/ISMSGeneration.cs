using System;
using System.Collections.Generic;
using System.Text;

namespace UserService
{
    public interface ISMSGeneration
    {
        int SMS(long contact);
    }
}
