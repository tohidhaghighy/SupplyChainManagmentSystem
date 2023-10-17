using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.Order;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class OrderService: IOrderService
    {
        public IOptions<Config.Config> Options { get; }

        public OrderService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<Order>>> Search(SearchOrderCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<Order>>>.Send(Options.Value.ApiSchmUrl + "/api/Order/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<Order>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<bool>> Cancel(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Order/Cancel" + id, Method.POST, "", false);
            return result.Result;
        }
    }
}
