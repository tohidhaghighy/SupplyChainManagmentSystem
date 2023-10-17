using Schm.Core.DTO.Request.Category;
using Schm.Core.DTO.Request.SubCategory;
using Schm.Core.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IItemCategoryService
    {
        Task<ResponseBody<List<ItemCatagory>>> GetList();
        Task<ResponseBody<List<ItemCatagory>>> Search(SearchItemCategoryCntx SearchCntx);
        Task<ResponseBody<ItemCatagory>> Get(int id);
        Task<ResponseBody<ItemCatagory>> Insert(InsertCategoryDto category, IFormFile image);
        Task<ResponseBody<bool>> Update(UpdateCategoryDto category, IFormFile image);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
