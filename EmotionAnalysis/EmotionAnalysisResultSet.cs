using System.Collections.Generic;
using System.Linq;

namespace EmotionAnalysis
{
    public class EmotionAnalysisResultSet
    {
        public bool FitToPlay => CalculateOverallResult();

        private bool CalculateOverallResult()
        {
            if (AgeDeteriation > 0)
                return false;

            if (EmotionAnalysisResults.Count == 0)
            {
                return true;
            }

            double saddest = EmotionAnalysisResults.Max(x => x.FaceAttributes.Emotion.Sadness);
            double happiest = EmotionAnalysisResults.Min(x => x.FaceAttributes.Emotion.Sadness);

            double minimumLevel = happiest * 0.8;

            if (saddest < minimumLevel)
            {
                return false;
            }

            saddest = EmotionAnalysisResults.Min(x => x.FaceAttributes.Emotion.Happiness);
            happiest = EmotionAnalysisResults.Max(x => x.FaceAttributes.Emotion.Happiness);
            minimumLevel = happiest * 0.8;

            if (saddest < minimumLevel)
            {
                return false;
            }

            return true;
        }

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
