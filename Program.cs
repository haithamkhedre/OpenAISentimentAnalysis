using Azure.AI.OpenAI;
using System;
using System.Collections.Generic;

namespace SentimentAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            var AOAI_KEY = "{Enter your Open AI API Key}";
            var openAIClient = new OpenAIClient(AOAI_KEY);
            Console.WriteLine("Sentiment Analysis POC using Azure Open AI SDK and Open AI gpt-3.5-turbo-instruct model");
            string input = string.Empty;
            do
            {
                // Get user input
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[Enter text to analyze]");
                input = Console.ReadLine();

                // Call Open AI, add quota if you don't have
                string model = "gpt-3.5-turbo-instruct";
                List<string> prompt = new List<string>() { $"Sentiment analysis of the following text:\n{input}\n" };
                var response = openAIClient.GetCompletions(new CompletionsOptions(model, prompt));
                string result = response.Value.Choices[0].Text.Trim();

                // Display the analysis result
                Console.ForegroundColor = ConsoleColor.Red;
                if(string.Equals(result,"Positive", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine($"Sentiment Analysis: {result}");

            }
            while (!string.Equals(input, "exit") && !string.IsNullOrWhiteSpace(input)) ;
        }
    }
}
