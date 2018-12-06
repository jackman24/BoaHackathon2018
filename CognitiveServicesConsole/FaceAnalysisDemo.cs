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
            var imageByteArray = GetImageAsByteArray("CognitiveServicesConsole.Images.ajacProfile.jpg");

            EmotionAnalysisEngine emotionAnalysis = new EmotionAnalysisEngine();

            await emotionAnalysis.AnalyseEmotion(Guid.NewGuid(), imageByteArray);
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
