using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmotionAnalysis.Models;
using Newtonsoft.Json;

namespace EmotionAnalysis
{
    public class EmotionAnalysisResult
    {
        [JsonProperty("faceId")]
        public Guid FaceId { get; set; }

        [JsonProperty("faceRectangle")]
        public FaceRectangle FaceRectangle { get; set; }

        [JsonProperty("faceAttributes")]
        public FaceAttributes FaceAttributes { get; set; }

        public byte[] Image { get; set; }

        public DateTime EventDateTime { get; set; }
    }
}
