using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IOrderDetailService
    {
        Task<ResponseBody<List<OrderDetail>>> GetList(int orderId);
    }
}
