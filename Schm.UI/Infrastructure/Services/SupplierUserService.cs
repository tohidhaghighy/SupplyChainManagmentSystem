using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.SupplierUser;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class SupplierUserService:ISupplierUserService
    {
        public IOptions<Config.Config> Options { get; }

        public SupplierUserService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<SupplierUser>>> GetList(int supplierId)
        {
            var result = SendRequest<ResponseBody<List<SupplierUser>>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierUser/List?supplierId="+supplierId , Method.GET, "", false);
            return new ResponseBody<List<SupplierUser>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<SupplierUser>>> Search(SearchSupplierUserCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<SupplierUser>>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierUser/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<SupplierUser>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<SupplierUser>> Get(int id)
        {
            var result = SendRequest<ResponseBody<SupplierUser>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierUser/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<SupplierUser>> Insert(InsertSupplierUserDto option)
        {
            var result = SendRequest<ResponseBody<SupplierUser>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierUser/Insert", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierUser/" + id, Method.POST, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Active(int id,bool active)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/SupplierUser/Active/" + id+"/"+ active, Method.POST, "", false);
            return result.Result;
        }
    }
}
