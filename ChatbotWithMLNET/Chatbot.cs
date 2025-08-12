using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotWithMLNET
{
    public class Chatbot
    {
        private static readonly string modelPath = "chatbotModel.zip";
        private PredictionEngine<ChatData, ChatPrediction> predictionEngine;

        public Chatbot()
        {
            var mlContext = new MLContext();
            ITransformer model = mlContext.Model.Load(modelPath, out _);
            predictionEngine = mlContext.Model.CreatePredictionEngine<ChatData, ChatPrediction>(model);
        }

        public string GetResponse(string input)
        {
            // Preprocess input (e.g., lowercasing, trimming spaces)
            input = PreprocessInput(input);

            // Predict answer based on user input
            var prediction = predictionEngine.Predict(new ChatData { Question = input });

            // If no valid answer is found, fallback mechanism
            if (string.IsNullOrEmpty(prediction?.Answer))
            {
                return "Sorry, I don't understand that question. Could you ask something else?";
            }

            return prediction.Answer;
        }

        private string PreprocessInput(string input)
        {
            // Simple text preprocessing (could be expanded to include stemming, removing stop words, etc.)
            input = input.ToLower().Trim();
            return input;
        }
    }
}
