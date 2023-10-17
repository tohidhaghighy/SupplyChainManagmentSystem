using Framework.Persistance;
using LTMS.Domain.Service;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class ItemCatagoryService : BaseCrudService<ItemCatagory>, IItemCatagoryService
    {
        public ItemCatagoryService(IRepository<ItemCatagory> repository) : base(repository)
        {
        }
    }
}
