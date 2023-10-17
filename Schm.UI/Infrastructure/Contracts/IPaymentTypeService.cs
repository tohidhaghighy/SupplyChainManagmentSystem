using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IPaymentTypeService
    {
        Task<ResponseBody<List<PaymentType>>> GetList();
    }
}
