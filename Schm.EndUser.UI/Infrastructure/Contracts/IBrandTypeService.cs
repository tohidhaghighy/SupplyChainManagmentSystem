using Schm.Core.SearchContext;
using Schm.Domain.Model;
using Schm.EndUser.UI.Infrastructure.Common;

namespace Schm.EndUser.UI.Infrastructure.Contracts
{
    public interface IBrandTypeService
    {
        Task<ResponseBody<List<BrandType>>> GetList();
    }
}
