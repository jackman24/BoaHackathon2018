using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using EmotionAnalysis;

namespace CognitiveServicesConsole
{
    public class FaceAnalysisDemo
    {
        public async Task Run()
        {
            EmotionAnalysisEngine emotionAnalysis = new EmotionAnalysisEngine();

            Guid sessionId = Guid.NewGuid();

            for (int i = 0; i < 4; i++)
            {
                var imageByteArray = GetImageAsByteArray($"CognitiveServicesConsole.Images.ajacProfile{i + 1}.jpg");
                var result = await emotionAnalysis.AnalyseEmotion(sessionId, imageByteArray);
            }

            var analysisResult = await emotionAnalysis.GetAnalysisResultSet(sessionId);
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
