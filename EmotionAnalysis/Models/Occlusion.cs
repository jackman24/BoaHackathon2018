using Newtonsoft.Json;

namespace EmotionAnalysis.Models
{
    public class Occlusion
    {
        [JsonProperty("foreheadOccluded")]
        public bool ForeheadOccluded { get; set; }

        [JsonProperty("eyeOccluded")]
        public bool EyeOccluded { get; set; }

        [JsonProperty("mouthOccluded")]
        public bool MouthOccluded { get; set; }
    }
}
