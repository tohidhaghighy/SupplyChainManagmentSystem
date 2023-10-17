using Framework.Persistance;
using Schm.Domain.Model;
using System.Threading.Tasks;

namespace Schm.Domain.IRepositroy
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<Item> GetItemDeteil(int itemId);
    }
}
