using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.ItemOption;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class ItemOptionService : IItemOptionService
    {
        public IOptions<Config.Config> Options { get; }

        public ItemOptionService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/ItemOption/" + id, Method.POST, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<ItemOption>> Get(int id)
        {
            var result = SendRequest<ResponseBody<ItemOption>>.Send(Options.Value.ApiSchmUrl + "/api/ItemOption/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<List<ItemOption>>> GetList()
        {
            var result = SendRequest<List<ItemOption>>.Send(Options.Value.ApiSchmUrl + "/api/ItemOption/List", Method.GET, "", false);
            return result;
        }

        public async Task<ResponseBody<ItemOption>> Insert(InsertItemOptionTypeDto itemOption)
        {
            var result = SendRequest<ResponseBody<ItemOption>>.Send(Options.Value.ApiSchmUrl + "/api/ItemOption/Insert", Method.POST, JsonConvert.SerializeObject(itemOption));
            return result.Result;
        }

        public async Task<ResponseBody<List<ItemOption>>> Search(SearchItemOptionCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<ItemOption>>>.Send(Options.Value.ApiSchmUrl + "/api/ItemOption/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<ItemOption>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }
    }
}
