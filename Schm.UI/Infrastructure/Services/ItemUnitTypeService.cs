using Microsoft.Extensions.Options;
using RestSharp;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class ItemUnitTypeService: IItemUnitTypeService
    {
        public IOptions<Config.Config> Options { get; }

        public ItemUnitTypeService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<ItemUnitType>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<ItemUnitType>>>.Send(Options.Value.ApiSchmUrl + "/api/ItemUnitType/List", Method.GET, "", false);
            return new ResponseBody<List<ItemUnitType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<ItemUnitType>> Get(int id)
        {
            var result = SendRequest<ResponseBody<ItemUnitType>>.Send(Options.Value.ApiSchmUrl + "/api/ItemUnitType/" + id, Method.GET, "", false);
            return result.Result;
        }
    }
}
