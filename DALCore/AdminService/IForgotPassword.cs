using Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserService
{
    public interface IForgotPassword
    {
        void ForgotPassword_SendAndUpdateOtp(string userId);
        bool ForgotPassword_CheckOtpEnteredByUser(string userId, int otpEnteredByUser);
        void SetNewPassword(string userId, string newPassword);

    }
}
