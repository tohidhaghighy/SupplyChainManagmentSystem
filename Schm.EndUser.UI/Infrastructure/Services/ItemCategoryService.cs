using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.SearchContext;
using Schm.Domain.Model;
using Schm.EndUser.UI.Infrastructure.Common;
using Schm.EndUser.UI.Infrastructure.Contracts;

namespace Schm.EndUser.UI.Infrastructure.Services
{
    public class ItemCategoryService: IItemCategoryService
    {
        public IOptions<Config.Config> Options { get; }

        public ItemCategoryService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<ItemCatagory>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<ItemCatagory>>>.Send(Options.Value.ApiSchmUrl + "/api/Category/List", Method.GET, "", false);
            return new ResponseBody<List<ItemCatagory>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

    }
}
