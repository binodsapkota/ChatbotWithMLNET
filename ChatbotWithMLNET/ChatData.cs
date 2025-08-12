using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotWithMLNET
{
    public class ChatData
    {
        [LoadColumn(0)]
        public string Question { get; set; }
        [LoadColumn(1)]
        public string Answer { get; set; }
    }

    public class ChatPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Answer { get; set; }
    }
}
