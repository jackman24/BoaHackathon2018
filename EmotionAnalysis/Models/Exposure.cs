using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmotionAnalysis.Models
{
    public class Exposure
    {
        [JsonProperty("exposureLevel")]
        public string ExposureLevel { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
