using cw.applicationservice.addproduct;
using cw.applicationservice.interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI_API;
using OpenAI_API.Completions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw.infrastructure.network
{
    public class BotApiService : IBotAPIService
    {
        private readonly IConfiguration _configuration;

        public BotApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<string>> GenerateContent(AdGenerateRequestModelDTO adGenerateRequestModel)
        {
            var apiKey = _configuration.GetSection("OpenAI:Key").Value;
            var apiModel = _configuration.GetSection("OpenAI:Model").Value;
            List<string> request = new List<string>();
            string response = "";
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));
            var completionRequest = new OpenAI_API.Completions.CompletionRequest()
            {
                Prompt = adGenerateRequestModel.prompt,
                Model = apiModel,
                Temperature = 0.5,
                MaxTokens = 100,
                TopP = 1.0,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,

            };

            var result = await api.Completions.CreateCompletionAsync(completionRequest);
            foreach (var item in result.Completions) {
                response = item.Text;
                request.Add(item.Text);
            }
            return request;
        }
    }
}
