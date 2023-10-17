using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Schm.Core.DTO.Request.DeliverySupplierPlan;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Contracts;

namespace Schm.UI.Infrastructure.Services
{
    public class DeliverySupplierPlanService: IDeliverySupplierPlanService
    {
        public IOptions<Config.Config> Options { get; }

        public DeliverySupplierPlanService(IOptions<Config.Config> options)
        {
            Options = options;
        }

        public async Task<ResponseBody<List<DeliverySupplierPlan>>> GetList(int supplierId)
        {
            var result = SendRequest<ResponseBody<List<DeliverySupplierPlan>>>.Send(Options.Value.ApiSchmUrl + "/api/DeliverySupplierPlan/List?supplierId=" + supplierId, Method.GET, "", false);
            return new ResponseBody<List<DeliverySupplierPlan>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<List<DeliverySupplierPlan>>> Search(SearchDeliverySupplierPlanCntxDto SearchCntx)
        {
            var result = SendRequest<ResponseBody<List<DeliverySupplierPlan>>>.Send(Options.Value.ApiSchmUrl + "/api/DeliverySupplierPlan/Search", Method.POST, JsonConvert.SerializeObject(SearchCntx));
            return new ResponseBody<List<DeliverySupplierPlan>>()
            {
                TotalCount = result.Result.TotalCount,
                Result = result.Result.Result,
                ErrorList = result.Result.ErrorList,
                IsSuccess = result.Result.IsSuccess
            };
        }

        public async Task<ResponseBody<DeliverySupplierPlan>> Get(int id)
        {
            var result = SendRequest<ResponseBody<DeliverySupplierPlan>>.Send(Options.Value.ApiSchmUrl + "/api/DeliverySupplierPlan/" + id, Method.GET, "", false);
            return result.Result;
        }

        public async Task<ResponseBody<DeliverySupplierPlan>> Insert(InsertDeliverySupplierPlanDto option)
        {
            var result = SendRequest<ResponseBody<DeliverySupplierPlan>>.Send(Options.Value.ApiSchmUrl + "/api/DeliverySupplierPlan/Insert", Method.POST, JsonConvert.SerializeObject(option));
            return result.Result;
        }

        public async Task<ResponseBody<bool>> Delete(int id)
        {
            var result = SendRequest<ResponseBody<bool>>.Send(Options.Value.ApiSchmUrl + "/api/DeliverySupplierPlan/" + id, Method.POST, "", false);
            return result.Result;
        }
    }
}
