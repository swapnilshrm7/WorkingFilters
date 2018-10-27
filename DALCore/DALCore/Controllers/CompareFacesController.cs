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
using Amazon.S3.Model;
using System.Security.AccessControl;
using UserService;

/*[HttpGet]
[Route("api/Guard")]
public async System.Threading.Tasks.Task<bool> CompareFacesAsync()
{
    GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
    ForgotPasswordManager obj = new ForgotPasswordManager();
    await obj.UploadToS3Async();
    try
    {
        AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient();
        var response = amazonRekognitionClient.SearchFacesByImage(new SearchFacesByImageRequest
        {
            CollectionId = "sample",
            FaceMatchThreshold = 80,
            Image = new Image
            {
                S3Object = new Amazon.Rekognition.Model.S3Object
                {
                    Bucket = "visitors-bucket",
                    Name = "new_visitor.jpg"
                }
            },
            MaxFaces = 5
        });
        if (response.FaceMatches.Any())
        {
            return true;
        }
        else
        {
            obj.AddANewFace();
            return false;
        }
    }
    catch (Exception exception)
    {
        return false;
    }
}*/

//using System;
//using System.Web.Http;
//using Amazon.Rekognition;
//using Amazon.Rekognition.Model;
//using Firebase.Storage;
//using System.IO;
//using Amazon.S3;
//using Amazon.S3.Model;
//using Microsoft.AspNetCore.Mvc;
//using System.Net;
//using System.Web;

//namespace DALCore.Controllers
//{
//    [ApiController]
//    public class CompareFacesController : ControllerBase
//    {
//        [System.Web.Http.HttpGet]
//        [System.Web.Http.Route("api/Guard")]
//        public async System.Threading.Tasks.Task<bool> CompareFacesAsync()
//        {
//            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
//            await UploadToS3Async();
//            try
//            {
//                AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient();
//                var response = amazonRekognitionClient.SearchFacesByImageAsync(new SearchFacesByImageRequest
//                {
//                    CollectionId = "sample",
//                    FaceMatchThreshold = 80,
//                    Image = new Image
//                    {
//                        S3Object = new Amazon.Rekognition.Model.S3Object
//                        {
//                            Bucket = "visitors-bucket",
//                            Name = "new_visitor.jpg"
//                        }
//                    },
//                    MaxFaces = 5
//                });
//                if (response.FaceMatches.Any())
//                {
//                    return true;
//                }
//                else
//                {
//                    AddANewFace();
//                    return false;
//                }
//                return true;
//            }
//            catch (Exception exception)
//            {
//                return false;
//            }
//        }
//        public async System.Threading.Tasks.Task UploadToS3Async()
//        {
//            var task = await new FirebaseStorage("taviscavisitor.appspot.com").Child("Visitors/visitor.jpg").GetDownloadUrlAsync();
//            string filePathToFirebaseStorage = task.ToString();
//            string filePathToLocalServer = HttpContext.HostingEnvirement.MapPath.MapPath("Visitors");
//            using (var client = new WebClient())
//            {
//                if (!Directory.Exists(filePathToLocalServer))
//                {
//                    Directory.CreateDirectory(filePathToLocalServer);
//                }
//                client.DownloadFile(filePathToFirebaseStorage, filePathToLocalServer + "/" + "visitor.jpg");
//            }

//            AmazonS3Client amazonS3Client = new AmazonS3Client();
//            PutObjectRequest putObjectRequest = new PutObjectRequest
//            {
//                BucketName = "visitors-bucket",
//                Key = "new_visitor.jpg",
//                FilePath = HttpContext.Current.Server.MapPath("Visitors") + "/" + "visitor.jpg"
//            };
//            await amazonS3Client.PutObjectAsync(putObjectRequest);
//        }

//        public void AddANewFace()
//        {
//            AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient();
//            var response = amazonRekognitionClient.IndexFacesAsync(new IndexFacesRequest
//            {
//                CollectionId = "sample",
//                ExternalImageId = new Guid().ToString(),
//                Image = new Image
//                {
//                    S3Object = new Amazon.Rekognition.Model.S3Object
//                    {
//                        Bucket = "visitors-bucket",
//                        Name = "new_visitor.jpg"
//                    }
//                }
//            });

//        }
//    }
//}
