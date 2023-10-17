using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.EndUser.UI.Infrastructure.Common;
using Schm.EndUser.UI.Infrastructure.Contracts;

namespace Schm.EndUser.UI.Infrastructure.Services
{
    public class ItemSubCategoryService: IItemSubCategoryService
    {
        public IOptions<Config.Config> Options { get; }

        public ItemSubCategoryService(IOptions<Config.Config> options)
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

    }
}
