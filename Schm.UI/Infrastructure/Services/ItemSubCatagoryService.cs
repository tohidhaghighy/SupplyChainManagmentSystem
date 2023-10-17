using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.SubCategory;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class ItemSubCatagoryService: IItemSubCatagoryService
    {
        public IOptions<Config.Config> Options { get; }

        public ItemSubCatagoryService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<ItemSubCatagory>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<ItemSubCatagory>>>.Send(Options.Value.ApiSchmUrl + "/api/SubCategory/List", Method.GET, "", false);
            return new ResponseBody<List<ItemSubCatagory>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<ItemSubCatagory>>> Search(SearchItemSubCatagoryCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<ItemSubCatagory>>>.Send(Options.Value.ApiSchmUrl + "/api/SubCategory/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<ItemSubCatagory>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<ItemSubCatagory>> Get(int id)
        {
            var result = SendRequest<ResponseBody<ItemSubCatagory>>.Send(Options.Value.ApiSchmUrl + "/api/SubCategory/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<ItemSubCatagory>> Insert(InsertSubCategoryDto category)
        {
            var result = SendRequest<ResponseBody<ItemSubCatagory>>.Send(Options.Value.ApiSchmUrl + "/api/SubCategory/Insert", Method.POST, JsonConvert.SerializeObject(category));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Update(UpdateSubCategoryDto category)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/SubCategory/Update", Method.POST, JsonConvert.SerializeObject(category));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/SubCategory/" + id, Method.POST, "", false);
            return result.Result;
        }

    }
}
