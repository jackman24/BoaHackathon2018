using CognitiveServicesCore;
using EmotionAnalysis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CognitiveServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // http://localhost:56420/api/emotionanalysis/c8684209-e2c1-4413-aa39-f87a423c4742
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
        public async Task<FaceAnalysisDocument> AnalyseEmotion(Guid sessionId, [FromBody] byte[] imageArray)
        {
            EmotionAnalysisEngine emotionAnalysisEngine = new EmotionAnalysisEngine();

            var response = await emotionAnalysisEngine.AnalyseEmotion(sessionId, imageArray).ConfigureAwait(false);
            return response;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
