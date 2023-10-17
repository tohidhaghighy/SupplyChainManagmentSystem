using Schm.Core.DTO.Request.OrderDetail;
using Schm.Domain.Model;
using Schm.EndUser.UI.Infrastructure.Common;

namespace Schm.EndUser.UI.Infrastructure.Contracts
{
    public interface IOrderDetailService
    {
        Task<ResponseBody<List<OrderDetail>>> GetList(int orderId);
        Task<ResponseBody<Order>> Insert(InsertOrderDetailDto option);
    }
}
