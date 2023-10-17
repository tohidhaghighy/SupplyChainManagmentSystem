using Schm.Core.DTO.SearchContext;
using Schm.EndUser.UI.Infrastructure.Common;
using Schm.EndUser.UI.Infrastructure.ViewModels;

namespace Schm.EndUser.UI.Infrastructure.Contracts
{
    public interface ISupplierItemService
    {
        Task<ResponseBody<List<SupplieItemViewModel>>> Search(SearchSupplierItemCntxDto SearchCntx);
    }
}
