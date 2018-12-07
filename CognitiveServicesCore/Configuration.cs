using System;

namespace CognitiveServicesCore
{
    public class Configuration
    {
        // Face Api Docs - https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236
        public static string FaceRecognitionApiUrl => "https://uksouth.api.cognitive.microsoft.com/face/v1.0";
        public static string FaceRecognitionKey => "26c69da42be948b2ab9d586fc5762a52";

        // Speaker Api Docs - https://westus.dev.cognitive.microsoft.com/docs/services/563309b6778daf02acc0a508/operations/5645c3271984551c84ec6797
        public static string SpeakerRecognitionApiUrl => "https://westus.api.cognitive.microsoft.com/spid/v1.0";
        public static string SpeakerRecognitionKey => "3d0530e638fd42e1bcf01ba3b94fdd2f";

        // Vision Api Docs - https://westus.dev.cognitive.microsoft.com/docs/services/56f91f2d778daf23d8ec6739/operations/56f91f2e778daf14a499e1fa
        public static string VisionApiUrl => "https://westus.api.cognitive.microsoft.com/spid/v1.0";
        public static string VisionKey => "4ec16e5f291c4151a741d12a378c0eb0";

        public static string CosmosUrl => "https://hackathon.documents.azure.com:443/";
        public static string CosmosKey => "OmvYuQLcpHMLctibFsxIkXMLupNMD6PivHCCnPVx2rq4eb3WFzHo0MCrVoginFj7SWGhH6v74hW12QIm7JbVZw==";
        public static string CosmosConnectionString => $"AccountEndpoint={CosmosUrl};AccountKey={CosmosKey};";
        public static string DatabaseName => "hackathon";
        public static string CollectionName => "hackathon";
    }
}
