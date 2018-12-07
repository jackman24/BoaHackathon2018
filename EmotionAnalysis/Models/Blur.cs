using Newtonsoft.Json;

namespace EmotionAnalysis.Models
{
    public class Blur
    {
        [JsonProperty("blurLevel")]
        public string BlurLevel { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
