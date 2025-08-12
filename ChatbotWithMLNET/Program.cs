using ChatbotWithMLNET;
using System;

class Program
{
    static void Main()
    {
        // Optionally train the model (skip if model is already trained and saved)
        // TrainingModel.TrainModel();

        // Load the trained model
        Chatbot chatbot = new Chatbot();

        // Start the chatbot interaction
        Console.WriteLine("Chatbot is ready! Type a message (or 'exit' to quit).");

        while (true)
        {
            Console.Write("You: ");
            string input = Console.ReadLine();

            // Exit condition
            if (input?.ToLower() == "exit") break;

            // Get chatbot response with fallback mechanism
            string response = chatbot.GetResponse(input);
            Console.WriteLine($"Bot: {response}\n");
        }
    }
}
