using System;
using OpenAI_API;

namespace ConsoleApp1
{
    class OpenAI
    {
        private static string ApiKey = "your_key";
        public static string AskOpenAI(string input)
        {
            var openAI = new OpenAIAPI(ApiKey);
            OpenAI_API.Completions.CompletionRequest completionRequest = new OpenAI_API.Completions.CompletionRequest();
            completionRequest.Prompt = "What is the solution of , " + Environment.NewLine + input;
            completionRequest.MaxTokens = 150;
            completionRequest.Temperature = 0.9;
            completionRequest.TopP = 1;
            completionRequest.FrequencyPenalty = 0;
            completionRequest.PresencePenalty = 0;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciCode;

            var completions = openAI.Completions.CreateCompletionAsync(completionRequest);
            string output = string.Empty;

            foreach (var comp in completions.Result.Completions)
            {
                output += comp.Text;
            }

            return output;
        }

    }
}
