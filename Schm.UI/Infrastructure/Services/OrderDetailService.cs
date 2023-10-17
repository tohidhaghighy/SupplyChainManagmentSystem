using Microsoft.Extensions.Options;
using RestSharp;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
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
            var result = SendRequest<ResponseBody<List<OrderDetail>>>.Send(Options.Value.ApiSchmUrl + "/api/Order/List/"+ orderId, Method.GET, "", false);
            return new ResponseBody<List<OrderDetail>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }
    }
}
