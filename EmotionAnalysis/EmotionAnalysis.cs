using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CognitiveServicesCore;
using Newtonsoft.Json.Linq;

namespace EmotionAnalysis
{
    public class EmotionAnalysisEngine
    {
        public async Task AnalyseEmotion(Guid sessionIdGuid, byte[] imageByteArray)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add(
                "Ocp-Apim-Subscription-Key", Configuration.FaceRecognitionKey);

            string requestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                                       "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses," +
                                       "emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";

            string uri = Configuration.FaceRecognitionApiUrl + "/detect?" + requestParameters;

            CosmosRepository cosmosRepository = new CosmosRepository();

            using (ByteArrayContent content = new ByteArrayContent(imageByteArray))
            {
                content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                HttpResponseMessage response = await client.PostAsync(uri, content);

                string contentString = await response.Content.ReadAsStringAsync();

                JObject json = JObject.Parse(contentString.Substring(1, contentString.Length - 2));

                await cosmosRepository.Create(new FaceAnalysisDocument()
                {
                    SessionId = sessionIdGuid,
                    EventDateTime = DateTime.UtcNow,
                    Image = imageByteArray,
                    Result = json
                });
            }
        }

        
    }
}
