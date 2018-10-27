using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Firebase;
using Firebase.Storage;
using Amazon.S3;
using Amazon.S3.Events;
using System.Security.AccessControl;

namespace FaceRekognition
{
    class Program
    {
        public async System.Threading.Tasks.Task UploadToS3Async()
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
            PutObjectRequest putObjectRequest = new PutObjectRequest
            {
                BucketName = "visitors-bucket",
                Key = "new_visitor.jpg",
                FilePath = HttpContext.Current.Server.MapPath("Visitors") + "/" + "visitor.jpg"
            };
            amazonS3Client.PutObject(putObjectRequest);
        }
    }
}
