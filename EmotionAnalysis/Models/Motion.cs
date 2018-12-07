using System;
using System.Collections.Generic;
namespace EmotionAnalysis.Models
{
    public class Emotion
    {
        public long Anger { get; set; }

        public double Contempt { get; set; }

        public long Disgust { get; set; }

        public long Fear { get; set; }

        public double Happiness { get; set; }

        public double Neutral { get; set; }

        public long Sadness { get; set; }

        public long Surprise { get; set; }
    }
}
