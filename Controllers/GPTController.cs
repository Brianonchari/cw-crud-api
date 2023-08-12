using cw.applicationservice.addproduct;
using cw.applicationservice.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cw.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class GPTController : ControllerBase
    {
        private readonly IADProductService _productService;
        public GPTController(IADProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<AdProductResponseModel>> generateContent(CustomerRequestModel customerRequest)
        {
            try
            {
                var response = await _productService.GenerateAdContent(customerRequest);
                return response;
            }catch(System.Exception ex)
            {
                return null;
            }
        }
    }
}
