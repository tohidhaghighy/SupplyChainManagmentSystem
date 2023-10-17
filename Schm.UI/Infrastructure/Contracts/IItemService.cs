using Schm.Core.DTO.Request.Item;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IItemService
    {
        Task<ResponseBody<List<Item>>> GetList();
        Task<ResponseBody<List<Item>>> Search(SearchItemCntxDto SearchCntx);
        Task<ResponseBody<Item>> Get(int id);
        Task<ResponseBody<Item>> Insert(InsertItemDto category);
        Task<ResponseBody<bool>> Update(UpdateItemDto category);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
