using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmotionAnalysis.Models
{
    public class Hair
    {
        [JsonProperty("bald")]
        public double Bald { get; set; }

        [JsonProperty("invisible")]
        public bool Invisible { get; set; }

        [JsonProperty("hairColor")]
        public object[] HairColor { get; set; }
    }
}
