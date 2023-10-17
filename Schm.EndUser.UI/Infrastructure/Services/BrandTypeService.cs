using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.SearchContext;
using Schm.Domain.Model;
using Schm.EndUser.UI.Infrastructure.Common;
using Schm.EndUser.UI.Infrastructure.Contracts;

namespace Schm.EndUser.UI.Infrastructure.Services
{
    public class BrandTypeService: IBrandTypeService
    {
        public IOptions<Config.Config> Options { get; }

        public BrandTypeService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<BrandType>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<BrandType>>>.Send(Options.Value.ApiSchmUrl + "/api/Brand/List", Method.GET, "", false);
            return new ResponseBody<List<BrandType>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

    }
}
