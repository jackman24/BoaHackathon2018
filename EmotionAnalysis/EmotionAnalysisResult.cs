using System;
using EmotionAnalysis.Models;

namespace EmotionAnalysis
{
    public class EmotionAnalysisResult
    {
        public Guid FaceId { get; set; }

        public FaceRectangle FaceRectangle { get; set; }

        public FaceAttributes FaceAttributes { get; set; }

        public byte[] Image { get; set; }

        public DateTime EventDateTime { get; set; }
    }
}
