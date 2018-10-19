using Core.Contracts;
using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace UserService
{
    public class UserLoginManager : IUserAuthentication
    { 
        public bool UserValidation(string UserId, string Password)
        {
            try
            {
                string salt = "tavisca";
                string hash = "";
                var entity = new VisitorsDatabaseContext();
                List<LoginCredentials> credentials = entity.LoginCredentials.FromSql("select * from LoginCredentials where UserId = @Id", new SqlParameter("@Id", UserId)).ToList<LoginCredentials>();
                Password += salt;
                Password += credentials[0].SavingTime;
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Password);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    hash = sb.ToString();
                }
                if (credentials[0].Password == hash)
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
