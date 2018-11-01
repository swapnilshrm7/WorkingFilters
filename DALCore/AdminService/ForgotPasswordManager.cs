using Core.Contracts.Models;
using DALCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Firebase;
using Firebase.Storage;
using Amazon.S3;
using Amazon.S3.Model;
using System.Security.AccessControl;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Microsoft.Net;
using SQLDatabase;
namespace UserService
{
    public class ForgotPasswordManager : IForgotPassword
    {
        public void ForgotPassword_SendAndUpdateOtp(string userId)
        {
            try
            {
                var entity = new DatabaseContext();
                UserDatabase sqlDB = new UserDatabase();
                LoginCredentials loginCredentials = sqlDB.GetLoginCredentialsByUserId(userId);
                SMSGeneration smsGeneration = new SMSGeneration();
                int otp = smsGeneration.SMS(Convert.ToInt64(loginCredentials.ContactNo));
                sqlDB.UpdateOTP(userId, otp);
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
                var entity = new DatabaseContext();
                UserDatabase sqlDB = new UserDatabase();
                LoginCredentials response = sqlDB.GetLoginCredentialsByUserId(userId);
                if (response.Otp==otpEnteredByUser)
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
                //var entity = new VisitorsDatabaseContext();
                //entity.Database.ExecuteSqlCommand("UPDATE LoginCredentials SET Password  = @newPassword , SavingTime =@savingTime WHERE UserId = @Id", new SqlParameter("@newPassword", hash), new SqlParameter("@savingTime", time), new SqlParameter("@Id", userId));
                UserDatabase sqlDB = new UserDatabase();
                sqlDB.UpdatePassword(userId, hash, time);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not update password. Please try again" + ex.StackTrace);
            }
        }
        /*async System.Threading.Tasks.Task UploadToS3Async()
        {
            var task = await new FirebaseStorage("taviscavisitor.appspot.com").Child("Visitors/visitor.jpg").GetDownloadUrlAsync();
            string filePathToFirebaseStorage = task.ToString();
            string filePathToLocalServer = HttpContext.Current.Server.MapPath("Visitors");
            using (var client = new WebClient())
            {
                if (!Directory.Exists(filePathToLocalServer))
                {
                    Directory.CreateDirectory(filePathToLocalServer);
                }
                client.DownloadFile(filePathToFirebaseStorage, filePathToLocalServer + "/" + "visitor.jpg");
            }

            AmazonS3Client amazonS3Client = new AmazonS3Client();
            Amazon.S3.Model.PutObjectRequest putObjectRequest = new Amazon.S3.Model.PutObjectRequest
            {
                BucketName = "visitors-bucket",
                Key = "new_visitor.jpg",
                FilePath = HttpContext.Current.Server.MapPath("Visitors") + "/" + "visitor.jpg"
            };
            amazonS3Client.PutObjectAsync(putObjectRequest);
        }

        void AddANewFace()
        {
            AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient();
            var response = amazonRekognitionClient.IndexFacesAsync(new IndexFacesRequest
            {
                CollectionId = "sample",
                ExternalImageId = new Guid().ToString(),
                Image = new Image
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object
                    {
                        Bucket = "visitors-bucket",
                        Name = "new_visitor.jpg"
                    }
                }
            });

        }*/
    }
}
