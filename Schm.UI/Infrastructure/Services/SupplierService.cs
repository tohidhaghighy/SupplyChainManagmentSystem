using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.Supplier;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class SupplierService: ISupplierService
    {
        public IOptions<Config.Config> Options { get; }

        public SupplierService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<Supplier>>> GetList()
        {
            var result = SendRequest<ResponseBody<List<Supplier>>>.Send(Options.Value.ApiSchmUrl + "/api/Supplier/List", Method.GET, "", false);
            return new ResponseBody<List<Supplier>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<Supplier>>> Search(SearchSupplierCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<Supplier>>>.Send(Options.Value.ApiSchmUrl + "/api/Supplier/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<Supplier>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<Supplier>> Get(int id)
        {
            var result = SendRequest<ResponseBody<Supplier>>.Send(Options.Value.ApiSchmUrl + "/api/Supplier/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<Supplier>> Insert(InsertSupplierDto option)
        {
            var result = SendRequest<ResponseBody<Supplier>>.Send(Options.Value.ApiSchmUrl + "/api/Supplier/Insert", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Update(UpdateSupplierDto option)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Supplier/Update", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/Supplier/" + id, Method.POST, "", false);
            return result.Result;
        }
    }
}
