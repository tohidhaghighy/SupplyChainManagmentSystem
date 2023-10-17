using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Response.Shop;
using Schm.Core.DTO.SearchContext;
using Schm.EndUser.UI.Infrastructure.Common;
using Schm.EndUser.UI.Infrastructure.Contracts;
using Schm.EndUser.UI.Infrastructure.ViewModels;

namespace Schm.EndUser.UI.Infrastructure.Services
{
    public class ShopService: IShopService
    {
        public IOptions<Config.Config> Options { get; }

        public ShopService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<ShopItemResponseDto>> Get(int itemId)
        {
            var result = SendRequest<ShopItemResponseDto>.Send(Options.Value.ApiSchmUrl + "/api/Shop/" + itemId, Method.GET, "", false);
            return result;
        }

        public async Task<ResponseBody<List<SupplieItemViewModel>>> Search(SearchShopCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<SupplieItemViewModel>>>.Send(Options.Value.ApiSchmUrl + "/api/Shop/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<SupplieItemViewModel>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }
    }
}
