using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmotionAnalysis
{
    public class EmotionAnalysisResult
    {
        [JsonProperty("faceAttributes.gender")]
        public string Gender { get; set; }

        [JsonProperty("faceAttributes.age")]
        public int Age { get; set; }
    }
}
