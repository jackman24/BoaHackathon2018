using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmotionAnalysis.Models
{
    public class Emotion
    {
        [JsonProperty("anger")]
        public long Anger { get; set; }

        [JsonProperty("contempt")]
        public double Contempt { get; set; }

        [JsonProperty("disgust")]
        public long Disgust { get; set; }

        [JsonProperty("fear")]
        public long Fear { get; set; }

        [JsonProperty("happiness")]
        public double Happiness { get; set; }

        [JsonProperty("neutral")]
        public double Neutral { get; set; }

        [JsonProperty("sadness")]
        public long Sadness { get; set; }

        [JsonProperty("surprise")]
        public long Surprise { get; set; }
    }
}
