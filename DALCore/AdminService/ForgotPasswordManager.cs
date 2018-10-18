using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace UserService
{
    public class ForgotPasswordManager
    {
        public void ForgotPassword_SendAndUpdateOtp(string userId)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                List<LoginCredentials> visitorCredentials = entity.LoginCredentials.FromSql("select * from LoginCredentials where UserId  = @Id", new SqlParameter("@Id", userId)).ToList<LoginCredentials>();
                SMSGeneration smsGeneration = new SMSGeneration();
                int otp = smsGeneration.SMS(Convert.ToInt64(visitorCredentials[0].ContactNo));
                entity.LoginCredentials.FromSql("UPDATE LoginCredentials SET Otp = @expectedOtp WHERE UserId = @Id;", new SqlParameter("@Id", userId), new SqlParameter("@expectedOtp", otp));
            }
            catch (Exception ex)
            {
                throw new Exception("Could not update password. Please try again" + ex.StackTrace);
            }
        }
        public bool ForgotPassword_CheckOtpEnteredByUser(string userId, int otpEnteredByUser)
        {
            try
            {
                var entity = new VisitorsDatabaseContext();
                if (entity.LoginCredentials.FromSql("select * from LoginCredentials where UserId  = @Id, Otp  = @otpEntered", new SqlParameter("@Id", userId), new SqlParameter("@otpEntered", otpEnteredByUser)) != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not update password. Please try again" + ex.StackTrace);
            }
        }
        public void SetNewPassword(string userId, string newPassword)
        {
            try
            {
                string salt = "tavisca";
                string time = "";
                string hash = "";
                newPassword += salt;
                time = DateTime.Now.ToString();
                newPassword += time;
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(newPassword);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    hash = sb.ToString();
                }
                var entity = new VisitorsDatabaseContext();
                entity.LoginCredentials.FromSql("UPDATE LoginCredentials SET Password  = @enewPassword and SavingTime =@savingTime WHERE UserId = @Id;", new SqlParameter("@Id", userId), new SqlParameter("@savingTime", time), new SqlParameter("@enewPassword", hash));
            }
            catch (Exception ex)
            {
                throw new Exception("Could not update password. Please try again" + ex.StackTrace);
            }
        }
    }
}
