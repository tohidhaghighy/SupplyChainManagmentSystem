using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.SearchContext;
using Schm.EndUser.UI.Infrastructure.Common;
using Schm.EndUser.UI.Infrastructure.Contracts;
using Schm.EndUser.UI.Infrastructure.ViewModels;

namespace Schm.EndUser.UI.Infrastructure.Services
{
    public class SupplierItemService: ISupplierItemService
    {
        public IOptions<Config.Config> Options { get; }

        public SupplierItemService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<SupplieItemViewModel>>> Search(SearchSupplierItemCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<SupplieItemViewModel>>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierItem/SearchForStore", Method.POST, JsonConvert.SerializeObject(SearchCntx));
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
