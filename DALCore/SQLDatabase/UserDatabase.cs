using System;
using System.Collections.Generic;
using System.Linq;
using DALCore.Models;
namespace SQLDatabase
{
    public class UserDatabase
    {
        public VisitorsDatabaseContext GetConnection()
        {
            return new VisitorsDatabaseContext();
        }
        public LoginCredentials GetLoginCredentialsByUserId(string userId)
        {
            var dbContext = GetConnection();
            var loginCredentials = dbContext.LoginCredentials.Find(userId);
            return loginCredentials;
        }

        public void UpdateOTP(string userId, int otp)
        {
            var dbContext = GetConnection();
            var loginCredential = dbContext.LoginCredentials.Find(userId);
            loginCredential.Otp = otp;
            dbContext.SaveChanges();
        }
        public void UpdatePassword(string userId, string password, string savingTime)
        {
            var dbContext = GetConnection();
            var loginCredential = dbContext.LoginCredentials.Find(userId);
            loginCredential.Password = password;
            loginCredential.SavingTime = savingTime;
            dbContext.SaveChanges();
        }
    }
}
