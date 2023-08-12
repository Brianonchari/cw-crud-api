using cw.applicationservice.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw.applicationservice.addproduct
{
    public class ADProductService : IADProductService
    {
        private readonly IBotAPIService _botAPIService;
        public ADProductService(IBotAPIService botAPIService)
        {
            _botAPIService = botAPIService;
        }


        public async Task<AdProductResponseModel> GenerateAdContent(CustomerRequestModel customerRequestModel)
        {
            if (string.IsNullOrEmpty(customerRequestModel.Message))
            {
                return new AdProductResponseModel
                {
                    Success = false,
                    AdContent = null
                };
            }

            var userMessage = new AdGenerateRequestModelDTO
            {
                prompt = customerRequestModel.Message,
            };

            var generateAd = await _botAPIService.GenerateContent(userMessage);
            if (generateAd.Count == 0)
            {
                return new AdProductResponseModel { Success = false, AdContent = null };
            }
            return new AdProductResponseModel
            {
                Success = true,
                AdContent = generateAd
            };
        }
    }
}
