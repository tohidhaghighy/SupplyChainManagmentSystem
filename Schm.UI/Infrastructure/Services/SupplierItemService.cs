using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.SupplierItem;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;
using Schm.UI.Infrastructure.ViewModels;

namespace Schm.UI.Infrastructure.Services
{
    public class SupplierItemService: ISupplierItemService
    {
        public IOptions<Config.Config> Options { get; }

        public SupplierItemService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<SupplieItemViewModel>>> GetList(int supplierId)
        {
            var result = SendRequest<ResponseBody<List<SupplieItemViewModel>>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierItem/List?supplierId=" + supplierId, Method.GET, "", false);
            return new ResponseBody<List<SupplieItemViewModel>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<SupplieItemViewModel>>> Search(SearchSupplierItemCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<SupplieItemViewModel>>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierItem/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<SupplieItemViewModel>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<SupplierItem>> Get(int id)
        {
            var result = SendRequest<ResponseBody<SupplierItem>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierItem/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<SupplierItem>> Insert(InsertSupplierItemDto option)
        {
            var result = SendRequest<ResponseBody<SupplierItem>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierItem/Insert", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Update(UpdateSupplierItemDto option)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierItem/Update", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierItem/" + id, Method.POST, "", false);
            return result.Result;
        }
    }
}
