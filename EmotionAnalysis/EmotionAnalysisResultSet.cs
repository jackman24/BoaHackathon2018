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

        public List<EmotionAnalysisResult> EmotionAnalysisResults { get; set; }

        public EmotionAnalysisResultSet()
        {
            EmotionAnalysisResults = new List<EmotionAnalysisResult>();
        }
    }
}
