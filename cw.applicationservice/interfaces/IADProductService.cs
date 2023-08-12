using cw.applicationservice.addproduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw.applicationservice.interfaces
{
    public interface IADProductService
    {
        Task<AdProductResponseModel> GenerateAdContent(CustomerRequestModel customerRequestModel);

    }
}
