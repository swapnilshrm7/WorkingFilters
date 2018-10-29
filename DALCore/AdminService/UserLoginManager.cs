using Core.Contracts;
using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using SQLDatabase;
namespace UserService
{
    public class UserLoginManager : IUserAuthentication
    { 
        public bool UserValidation(string userId, string password)
        {
            try
            {
                string salt = "tavisca";
                string hash = "";
                UserDatabase sqlDB = new UserDatabase();
                LoginCredentials credentials = sqlDB.GetLoginCredentialsByUserId(userId);
                password += salt;
                password += credentials.SavingTime;
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    hash = sb.ToString();
                }
                if (credentials.Password == hash)
                    return true;
                else
                    return false; 
            }
            catch (Exception ex)
            {
                throw new Exception("Validation Failed! Please Contact Admin" + ex.StackTrace);
            }
        }
    }
}
