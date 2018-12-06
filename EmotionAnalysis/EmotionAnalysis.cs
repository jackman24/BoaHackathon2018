using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CognitiveServicesCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmotionAnalysis
{
    public class EmotionAnalysisEngine
    {
        public async Task<FaceAnalysisDocument> AnalyseEmotion(Guid sessionIdGuid, byte[] imageByteArray)
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

                JArray results = JArray.Parse(contentString);

                if (results.Count > 0)
                {
                    JObject json = JObject.Parse(results[0].ToString());

                    FaceAnalysisDocument faceAnalysisDocument = new FaceAnalysisDocument
                    {
                        SessionId = sessionIdGuid,
                        EventDateTime = DateTime.UtcNow,
                        Image = imageByteArray,
                        Result = json
                    };

                    await cosmosRepository.Create(faceAnalysisDocument);

                    return faceAnalysisDocument;
                }

                return new FaceAnalysisDocument();
            }
        }

        public async Task<EmotionAnalysisResultSet> GetAnalysisResultSet(Guid sessionIdGuid)
        {
            CosmosRepository cosmosRepository = new CosmosRepository();

            var resultSet = await cosmosRepository.GetFaceAnalysisResults(sessionIdGuid);

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();

            foreach (FaceAnalysisDocument faceAnalysisDocument in resultSet)
            {
                JsonConvert.DeserializeObject<List<EmotionAnalysisResult>>(faceAnalysisDocument.Result.ToString());
            }

            return new EmotionAnalysisResultSet();
        }
    }
}
