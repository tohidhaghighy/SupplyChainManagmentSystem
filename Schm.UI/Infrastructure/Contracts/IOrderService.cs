using Schm.Core.DTO.Request.Order;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IOrderService
    {
        Task<ResponseBody<List<Order>>> Search(SearchOrderCntxDto SearchCntx);
        Task<ResponseBody<bool>> Cancel(int id);
    }
}
