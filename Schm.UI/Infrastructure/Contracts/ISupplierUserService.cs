using Schm.Core.DTO.Request.SupplierUser;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface ISupplierUserService
    {
        Task<ResponseBody<List<SupplierUser>>> GetList(int supplierId);
        Task<ResponseBody<List<SupplierUser>>> Search(SearchSupplierUserCntxDto SearchCntx);
        Task<ResponseBody<SupplierUser>> Get(int id);
        Task<ResponseBody<SupplierUser>> Insert(InsertSupplierUserDto option);
        Task<ResponseBody<bool>> Delete(int id);
        Task<ResponseBody<bool>> Active(int id, bool active);
    }
}
