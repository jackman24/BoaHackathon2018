using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionAnalysis
{
    public class EmotionAnalysisResultSet
    {
        public List<EmotionAnalysisResult> EmotionAnalysisResults { get; set; }

        public EmotionAnalysisResultSet()
        {
            EmotionAnalysisResults = new List<EmotionAnalysisResult>();
        }

        // properties to calculate state of individual

        public long AgeDeteriation => EmotionAnalysisResults.Max(x => x.FaceAttributes.Age) -
                                     EmotionAnalysisResults.Min(x => x.FaceAttributes.Age);
    }
}
