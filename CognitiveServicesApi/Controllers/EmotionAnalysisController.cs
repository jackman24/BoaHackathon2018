using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CognitiveServicesCore;
using EmotionAnalysis;

namespace CognitiveServicesApi.Controllers
{
    public class EmotionAnalysisController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(EmotionAnalysisResultSet))]
        [Route("api/emotionanalysis/{sessionId:Guid}")]
        public async Task<EmotionAnalysisResultSet> GetFaceAnalysisResultSetBySessionId([FromUri] Guid sessionId)
        {
            EmotionAnalysisEngine emotionAnalysisEngine = new EmotionAnalysisEngine();

            var response = await emotionAnalysisEngine.GetAnalysisResultSet(sessionId).ConfigureAwait(false);
            return response;
        }

        [HttpPost]
        [ResponseType(typeof(FaceAnalysisDocument))]
        [Route("api/emotionanalysis/{sessionId:Guid}")]
        public async Task<FaceAnalysisDocument> AnalyseEmotion([FromUri] Guid sessionId, byte[] imageArray)
        {
            EmotionAnalysisEngine emotionAnalysisEngine = new EmotionAnalysisEngine();

            var response = await emotionAnalysisEngine.AnalyseEmotion(sessionId, imageArray).ConfigureAwait(false);
            return response;
        }
    }
}