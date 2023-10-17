using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.EndUser.UI.Infrastructure.Common;

namespace Schm.EndUser.UI.Infrastructure.Contracts
{
    public interface IItemSubCategoryService
    {
        Task<ResponseBody<List<ItemSubCatagory>>> GetList();
    }
}
