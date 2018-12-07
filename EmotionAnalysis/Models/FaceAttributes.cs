using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmotionAnalysis.Models
{
    public class FaceAttributes
    {
        [JsonProperty("smile")]
        public double Smile { get; set; }

        [JsonProperty("headPose")]
        public HeadPose HeadPose { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("facialHair")]
        public FacialHair FacialHair { get; set; }

        [JsonProperty("glasses")]
        public string Glasses { get; set; }

        [JsonProperty("emotion")]
        public Emotion Emotion { get; set; }

        [JsonProperty("blur")]
        public Blur Blur { get; set; }

        [JsonProperty("exposure")]
        public Exposure Exposure { get; set; }

        [JsonProperty("noise")]
        public Noise Noise { get; set; }

        [JsonProperty("makeup")]
        public Makeup Makeup { get; set; }

        [JsonProperty("accessories")]
        public object[] Accessories { get; set; }

        [JsonProperty("occlusion")]
        public Occlusion Occlusion { get; set; }

        [JsonProperty("hair")]
        public Hair Hair { get; set; }
    }
}
