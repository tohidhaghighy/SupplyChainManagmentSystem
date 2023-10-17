using Schm.Core.DTO.Request;
using Schm.Core.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IBrandTypeService
    {
        Task<ResponseBody<List<BrandType>>> GetList();
        Task<ResponseBody<BrandType>> Get(int id);
        Task<ResponseBody<List<BrandType>>> Search(SearchBrandCntx SearchCntx);
        Task<ResponseBody<BrandType>> Insert(InsertBrandTypeDto brand, IFormFile image);
        Task<ResponseBody<bool>> Update(UpdateBrandTypeDto brand, IFormFile image);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
