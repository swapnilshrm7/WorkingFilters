using System;

namespace FaceRecognition
{ 
//{
//    [ApiController]
//    class FaceRekognition
//    { 
       

//        public async System.Threading.Tasks.Task UploadToS3Async()
//        {
//            var task = await new FirebaseStorage("taviscavisitor.appspot.com").Child("Visitors/visitor.jpg").GetDownloadUrlAsync();
//            string filePathToFirebaseStorage = task.ToString();
//            string filePathToLocalServer = HttpContext.Current.Server.MapPath("Visitors");
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
//            amazonS3Client.PutObject(putObjectRequest);
//        }

//        public void AddANewFace()
//        {
//            AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient();
//            var response = amazonRekognitionClient.IndexFaces(new IndexFacesRequest
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
}