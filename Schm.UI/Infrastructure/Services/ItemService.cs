using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.Item;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class ItemService: IItemService
    {
        public IOptions<Config.Config> Options { get; }

        public ItemService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<Item>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<Item>>>.Send(Options.Value.ApiSchmUrl + "/api/Item/List", Method.GET, "", false);
            return new ResponseBody<List<Item>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<Item>>> Search(SearchItemCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<Item>>>.Send(Options.Value.ApiSchmUrl + "/api/Item/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<Item>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<Item>> Get(int id)
        {
            var result = SendRequest<ResponseBody<Item>>.Send(Options.Value.ApiSchmUrl + "/api/Item/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<Item>> Insert(InsertItemDto category)
        {
            var result = SendRequest<ResponseBody<Item>>.Send(Options.Value.ApiSchmUrl + "/api/Item/Insert", Method.POST, JsonConvert.SerializeObject(category));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Update(UpdateItemDto category)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Item/Update", Method.POST, JsonConvert.SerializeObject(category));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Item/" + id, Method.POST, "", false);
            return result.Result;
        }

    }
}
