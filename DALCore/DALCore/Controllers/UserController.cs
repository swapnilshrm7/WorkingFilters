using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService;
using Core.Contracts;
using GuardService;
using Core.Contracts.Models;
using Newtonsoft.Json.Linq;

namespace DALCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserAuthentication admin;
        IForgotPassword user;
        public UserController(IUserAuthentication _admin)
        {
            admin = _admin;
        }
        public UserController(IForgotPassword _user)
        {
            user = _user;
        }
        [HttpPut]
        public bool ValidateUser([FromBody]LoginBasicDetails loginBasicDetails)
        {
            return admin.UserValidation(loginBasicDetails.UserId, loginBasicDetails.Password);
        }
        [HttpPut]
        public void ForgotPasswordOtp(string userId)
        {
            user.ForgotPassword_SendAndUpdateOtp(userId);
        }
        [HttpPut]
        public void ForgotPassword_ValidateUserByOtp(string userId, int otp)
        {
            user.ForgotPassword_CheckOtpEnteredByUser(userId, otp);
        }
        [HttpPut]
        public void ResetPassword(string userId, string newPassword)
        {
            user.SetNewPassword(userId, newPassword);
        }
    }
}