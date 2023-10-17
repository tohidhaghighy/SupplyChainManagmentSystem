using Schm.Core.DTO.Request.Order;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.EndUser.UI.Infrastructure.Common;

namespace Schm.EndUser.UI.Infrastructure.Contracts
{
    public interface IOrderService
    {
        Task<ResponseBody<List<Order>>> Search(SearchOrderCntxDto SearchCntx);
        Task<ResponseBody<Order>> Insert(InsertOrderDto option);
        Task<ResponseBody<bool>> Cancel(int id);
    }
}
