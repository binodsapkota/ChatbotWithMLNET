using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotWithMLNET
{
    public static class ModelTrainer
    {
        private static readonly string dataPath = @"C:\OCR_Folder\chatbot\trainingData.csv";
        private static readonly string modelPath = "chatbotModel.zip";


        public static void TrainModel()
        {
            var mlContext = new MLContext();

            // Load Data
            IDataView dataView = mlContext.Data.LoadFromTextFile<ChatData>(dataPath, separatorChar: ',', hasHeader: true);

            // Define Pipeline
            var pipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(ChatData.Question))
            .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Answer", "Features"))
            .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // Train Model
            var model = pipeline.Fit(dataView);

            // Save Model
            mlContext.Model.Save(model, dataView.Schema, modelPath);

            Console.WriteLine("Model trained and saved successfully!");
        }
    }

}
