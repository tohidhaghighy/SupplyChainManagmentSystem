using Schm.Core.DTO.Request.ItemOption;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IItemOptionService
    {
        Task<ResponseBody<List<ItemOption>>> GetList();
        Task<ResponseBody<List<ItemOption>>> Search(SearchItemOptionCntxDto SearchCntx);
        Task<ResponseBody<ItemOption>> Get(int id);
        Task<ResponseBody<ItemOption>> Insert(InsertItemOptionTypeDto category);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
