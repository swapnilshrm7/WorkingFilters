using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService;

namespace DALCore.Controllers
{ 
    [ApiController]
    public class PasswordManipulationController : ControllerBase
    {
        IForgotPassword user;
        public PasswordManipulationController(IForgotPassword _user)
        {
            user = _user;
        }
        [HttpPut]
        [Route("api/[controller]/ForgotPassword_Otp")]
        public void ForgotPasswordOtp(SearchFilter userId)
        {
            user.ForgotPassword_SendAndUpdateOtp(userId.UserInput);
        }
        [HttpPut]
        [Route("api/[controller]/ForgotPassword_Validation")]
        public bool ForgotPassword_ValidateUserByOtp(IdAndOtp UserInput)
        {
            return user.ForgotPassword_CheckOtpEnteredByUser(UserInput.UserId, UserInput.Otp);
        }
        [HttpPut]
        [Route("api/[controller]/ForgotPassword_ResetPassword")]
        public string ResetPassword(LoginBasicDetails UserInput)
        {
            user.SetNewPassword(UserInput.UserId, UserInput.Password);
            return "Password changed successfully";
        }
    }
}