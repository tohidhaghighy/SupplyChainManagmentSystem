using Schm.Domain.Model;
using Schm.UI.Infrastructure.Common;

namespace Schm.UI.Infrastructure.Contracts
{
    public interface IItemUnitTypeService
    {
        Task<ResponseBody<List<ItemUnitType>>> GetList();
        Task<ResponseBody<ItemUnitType>> Get(int id);
    }
}
