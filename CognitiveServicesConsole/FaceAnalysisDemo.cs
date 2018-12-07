using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using CognitiveServicesCore;

namespace CognitiveServicesConsole
{
    public class FaceAnalysisDemo
    {
        public async Task Run()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", Configuration.FaceRecognitionKey);

            string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                                       "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses," +
                                       "emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

            string uri = Configuration.FaceRecognitionApiUrl + "/detect?" + requestParameters;

            var imageByteArray = GetImageAsByteArray("CognitiveServicesConsole.Images.ajacProfile.jpg");

            using (ByteArrayContent content = new ByteArrayContent(imageByteArray))
            {
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                string contentString = await response.Content.ReadAsStringAsync();

                Console.WriteLine("\nResponse:\n");
                Console.WriteLine(contentString);
                Console.WriteLine("\nPress Enter to exit...");
            }
        }

        private byte[] GetImageAsByteArray(string imageFilePath)
        {
            var thisAssembly = Assembly.GetExecutingAssembly();

            using (var imageStream = thisAssembly.GetManifestResourceStream(imageFilePath))
            {
                BinaryReader binaryReader = new BinaryReader(imageStream);
                return binaryReader.ReadBytes((int)imageStream.Length);
            }
        }
    }
}
