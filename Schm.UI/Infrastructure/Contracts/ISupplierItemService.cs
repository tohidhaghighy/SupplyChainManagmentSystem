using Schm.Core.DTO.Request.SupplierItem;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.ViewModels;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface ISupplierItemService
    {
        Task<ResponseBody<List<SupplieItemViewModel>>> GetList(int supplierId);
        Task<ResponseBody<List<SupplieItemViewModel>>> Search(SearchSupplierItemCntxDto SearchCntx);
        Task<ResponseBody<SupplierItem>> Get(int id);
        Task<ResponseBody<SupplierItem>> Insert(InsertSupplierItemDto option);
        Task<ResponseBody<bool>> Update(UpdateSupplierItemDto option);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
