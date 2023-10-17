using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.OrderDetail;
using Schm.Domain.Model;
using Schm.EndUser.UI.Infrastructure.Common;
using Schm.EndUser.UI.Infrastructure.Contracts;

namespace Schm.EndUser.UI.Infrastructure.Services
{
    public class OrderDetailService: IOrderDetailService
    {
        public IOptions<Config.Config> Options { get; }

        public OrderDetailService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<OrderDetail>>> GetList(int orderId)
        {
            var result = SendRequest<ResponseBody<List<OrderDetail>>>.Send(Options.Value.ApiSchmUrl + "/api/OrderDetail/List/"+ orderId, Method.GET, "", false);
            return new ResponseBody<List<OrderDetail>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<Order>> Insert(InsertOrderDetailDto option)
        {
            var result = SendRequest<ResponseBody<Order>>.Send(Options.Value.ApiSchmUrl + "/api/OrderDetail/Insert", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }
    }
}
