using System;
using System.Threading.Tasks;
using CognitiveServicesCore;
using EmotionAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace CognitiveServicesApi.Controllers
{
    public class EmotionAnalysisController : Controller
    {
        [HttpGet]
        [Route("api/emotionanalysis/{sessionId}")]
        public async Task<EmotionAnalysisResultSet> GetFaceAnalysisResultSetBySessionId(Guid sessionId)
        {
            EmotionAnalysisEngine emotionAnalysisEngine = new EmotionAnalysisEngine();

            var response = await emotionAnalysisEngine.GetAnalysisResultSet(sessionId).ConfigureAwait(false);
            return response;
        }

        [HttpPost]
        [Route("api/emotionanalysis/{sessionId}")]
        public async Task<FaceAnalysisDocument> AnalyseEmotion(Guid sessionId, byte[] imageArray)
        {
            EmotionAnalysisEngine emotionAnalysisEngine = new EmotionAnalysisEngine();

            var response = await emotionAnalysisEngine.AnalyseEmotion(sessionId, imageArray).ConfigureAwait(false);
            return response;
        }
    }
}