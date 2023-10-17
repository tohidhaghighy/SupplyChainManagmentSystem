using Schm.Core.DTO.Request.Supplier;
using Schm.Core.DTO.SearchContext;
using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface ISupplierService
    {
        Task<ResponseBody<List<Supplier>>> GetList();
        Task<ResponseBody<List<Supplier>>> Search(SearchSupplierCntxDto SearchCntx);
        Task<ResponseBody<Supplier>> Get(int id);
        Task<ResponseBody<Supplier>> Insert(InsertSupplierDto option);
        Task<ResponseBody<bool>> Update(UpdateSupplierDto option);
        Task<ResponseBody<bool>> Delete(int id);
    }
}
