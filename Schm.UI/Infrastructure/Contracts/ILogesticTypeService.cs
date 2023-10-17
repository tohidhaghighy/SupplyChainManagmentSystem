using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface ILogesticTypeService
    {
        Task<ResponseBody<List<LogesticType>>> GetList();
    }
}
