using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using System;
using System.Linq;

namespace FaceService
{
    public class FaceManager
    {
        public async System.Threading.Tasks.Task<bool> CompareFacesAsync()
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
                    return true;
                else
                    return false;
            }
            catch (Exception exception)
            {
                return false;
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
    }
}
