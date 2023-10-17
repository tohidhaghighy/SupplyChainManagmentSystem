using Microsoft.Extensions.Options;
using RestSharp;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class PaymentTypeService: IPaymentTypeService
    {
        public IOptions<Config.Config> Options { get; }

        public PaymentTypeService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<PaymentType>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<PaymentType>>>.Send(Options.Value.ApiSchmUrl + "/api/PaymentType/List", Method.GET, "", false);
            return new ResponseBody<List<PaymentType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }
    }
}
