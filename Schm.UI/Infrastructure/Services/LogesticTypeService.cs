using Microsoft.Extensions.Options;
using RestSharp;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class LogesticTypeService: ILogesticTypeService
    {
        public IOptions<Config.Config> Options { get; }

        public LogesticTypeService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<LogesticType>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<LogesticType>>>.Send(Options.Value.ApiSchmUrl + "/api/LogesticType/List", Method.GET, "", false);
            return new ResponseBody<List<LogesticType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

    }
}
