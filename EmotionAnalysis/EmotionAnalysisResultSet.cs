using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionAnalysis
{
    public class EmotionAnalysisResultSet
    {
        // properties to calculate state of individual

        public long AgeDeteriation
        {
            get
            {
                if (EmotionAnalysisResults.Count == 0)
                    return 0;

                return EmotionAnalysisResults.Max(x => x.FaceAttributes.Age) -
                       EmotionAnalysisResults.Min(x => x.FaceAttributes.Age);
            }
        }

        public double Sadness
        {
            get
            {
                if (EmotionAnalysisResults.Count == 0)
                {
                    return 0;
                }

                return EmotionAnalysisResults.First().FaceAttributes.Emotion.Sadness -
                       EmotionAnalysisResults.Last().FaceAttributes.Emotion.Sadness;
            }
        }

        public double Happiness
        {
            get
            {
                if (EmotionAnalysisResults.Count == 0)
                {
                    return 0;
                }

                return EmotionAnalysisResults.First().FaceAttributes.Emotion.Happiness -
                       EmotionAnalysisResults.Last().FaceAttributes.Emotion.Happiness;
            }
        }

        public double Smile
        {
            get
            {
                if (EmotionAnalysisResults.Count == 0)
                {
                    return 0;
                }

                return EmotionAnalysisResults.First().FaceAttributes.Smile -
                       EmotionAnalysisResults.Last().FaceAttributes.Smile;
            }
        }

        public double Anger
        {
            get
            {
                if (EmotionAnalysisResults.Count == 0)
                {
                    return 0;
                }

                return EmotionAnalysisResults.First().FaceAttributes.Emotion.Anger -
                       EmotionAnalysisResults.Last().FaceAttributes.Emotion.Anger;
            }
        }

        public double Disgust
        {
            get
            {
                if (EmotionAnalysisResults.Count == 0)
                {
                    return 0;
                }

                return EmotionAnalysisResults.First().FaceAttributes.Emotion.Disgust -
                       EmotionAnalysisResults.Last().FaceAttributes.Emotion.Disgust;
            }
        }

        public List<EmotionAnalysisResult> EmotionAnalysisResults { get; set; }

        public EmotionAnalysisResultSet()
        {
            EmotionAnalysisResults = new List<EmotionAnalysisResult>();
        }
    }
}
