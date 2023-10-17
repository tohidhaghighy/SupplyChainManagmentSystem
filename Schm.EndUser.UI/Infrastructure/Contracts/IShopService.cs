using Schm.Core.DTO.Response.Shop;
using Schm.Core.DTO.SearchContext;
using Schm.EndUser.UI.Infrastructure.Common;
using Schm.EndUser.UI.Infrastructure.ViewModels;

namespace Schm.EndUser.UI.Infrastructure.Contracts
{
    public interface IShopService
    {
        Task<ResponseBody<ShopItemResponseDto>> Get(int itemId);
        Task<ResponseBody<List<SupplieItemViewModel>>> Search(SearchShopCntxDto SearchCntx);
    }
}
