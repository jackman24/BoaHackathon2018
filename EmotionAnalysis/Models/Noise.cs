using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmotionAnalysis.Models
{
    public class Noise
    {
        [JsonProperty("noiseLevel")]
        public string NoiseLevel { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
