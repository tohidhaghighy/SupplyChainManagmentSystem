using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IOrderStatusService
    {
        Task<ResponseBody<List<OrderStatus>>> GetList();
    }
}
