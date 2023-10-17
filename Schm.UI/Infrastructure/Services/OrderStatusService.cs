using Microsoft.Extensions.Options;
using RestSharp;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class OrderStatusService: IOrderStatusService
    {
        public IOptions<Config.Config> Options { get; }

        public OrderStatusService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<OrderStatus>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<OrderStatus>>>.Send(Options.Value.ApiSchmUrl + "/api/OrderStatus/List", Method.GET, "", false);
            return new ResponseBody<List<OrderStatus>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }
    }
}
