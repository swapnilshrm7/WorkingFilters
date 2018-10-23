using System;
using System.Collections.Generic;
using System.Text;

namespace UserService
{
    public interface IUserAuthentication
    {
        bool UserValidation(string UserId, string Password); 
    }
}
