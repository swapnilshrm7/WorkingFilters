using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using DALCore.Models;
using System;
using System.Linq;

namespace FaceService
{
    public class FaceManager : IFace
    {
        public async System.Threading.Tasks.Task<string> CompareFacesAsync(string collectionName)
        {
            try
            {
                string accessKeyId = "AKIAJM4TC3NLKAVPLCFQ";
                string secretAccessKey = "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";
                BasicAWSCredentials basicAWSCredentials = new BasicAWSCredentials(accessKeyId, secretAccessKey);
                AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient(basicAWSCredentials);
                var response = await amazonRekognitionClient.SearchFacesByImageAsync(new SearchFacesByImageRequest
                {
                    CollectionId = collectionName,
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
                    int imageId = Convert.ToInt32(response.FaceMatches[0].Face.ExternalImageId);
                    return GetVisitorNameById(imageId);
                }
                    
                else
                    return "No Match Found";
            }
            catch (Exception exception)
            {
                return exception.StackTrace;
            }
        }

        public void AddANewFace(string imageId)
        {
            AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient();
            var response = amazonRekognitionClient.IndexFacesAsync(new IndexFacesRequest
            {
                CollectionId = "visitors",
                ExternalImageId = imageId,
                Image = new Image
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object
                    {
                        Bucket = "visitors-bucket",
                        Name = "new_visitor.jpg"
                    }
                }
            });
        }
        public string GetVisitorNameById(int Id)
        {
            try
            {
                var entity = new DatabaseContext();
                Visitors Visitor = entity.Visitors.Where(entry => entry.VisitorId == Id).FirstOrDefault();
                return Visitor.NameOfVisitor;
            }
            catch (Exception ex)
            {
                return "Unable to fetch name";
            }
        }
    }
}
