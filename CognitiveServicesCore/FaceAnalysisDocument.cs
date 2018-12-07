using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace CognitiveServicesCore
{
    public class FaceAnalysisDocument
    {
        public Guid SessionId { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime EventDateTime { get; set; }

        public byte[] Image { get; set; }

        public JObject Result { get; set; }
    }
}
