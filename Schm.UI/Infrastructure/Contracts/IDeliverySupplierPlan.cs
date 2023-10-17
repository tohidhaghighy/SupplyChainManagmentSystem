using Schm.Core.DTO.Request.DeliverySupplierPlan;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IDeliverySupplierPlanService
    {
        Task<ResponseBody<List<DeliverySupplierPlan>>> GetList(int supplierId);
        Task<ResponseBody<List<DeliverySupplierPlan>>> Search(SearchDeliverySupplierPlanCntxDto SearchCntx);
        Task<ResponseBody<DeliverySupplierPlan>> Get(int id);
        Task<ResponseBody<DeliverySupplierPlan>> Insert(InsertDeliverySupplierPlanDto option);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
