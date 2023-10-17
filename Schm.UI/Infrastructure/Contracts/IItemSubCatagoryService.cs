using Schm.Core.DTO.Request.SubCategory;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IItemSubCatagoryService
    {
        Task<ResponseBody<List<ItemSubCatagory>>> GetList();
        Task<ResponseBody<List<ItemSubCatagory>>> Search(SearchItemSubCatagoryCntxDto SearchCntx);
        Task<ResponseBody<ItemSubCatagory>> Get(int id);
        Task<ResponseBody<ItemSubCatagory>> Insert(InsertSubCategoryDto category);
        Task<ResponseBody<bool>> Update(UpdateSubCategoryDto category);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
