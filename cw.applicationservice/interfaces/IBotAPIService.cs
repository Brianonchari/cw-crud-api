using cw.applicationservice.addproduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw.applicationservice.interfaces
{
    public interface IBotAPIService
    {
        Task<List<string>> GenerateContent(AdGenerateRequestModelDTO adGenerateRequestModel);
    }
}
