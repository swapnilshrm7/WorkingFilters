using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using DALCore.Models;
using System;
using System.Linq;

namespace FaceService
{
    public class FaceManager : IFace
    {
        public async System.Threading.Tasks.Task<string> CompareFacesAsync()
        {
            try
            {
                AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient();
                var response = await amazonRekognitionClient.SearchFacesByImageAsync(new SearchFacesByImageRequest
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
                    int imageId = Convert.ToInt32(response.FaceMatches[0].Face.ExternalImageId);
                    return GetVisitorNameById(imageId);
                }
                    
                else
                    return "No Match Found";
            }
            catch (Exception exception)
            {
                return "Error";
            }
        }

        public void AddANewFace(string imageId)
        {
            AmazonRekognitionClient amazonRekognitionClient = new AmazonRekognitionClient();
            var response = amazonRekognitionClient.IndexFacesAsync(new IndexFacesRequest
            {
                CollectionId = "sample",
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
                var entity = new VisitorsDatabaseContext();
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
