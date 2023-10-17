using Framework.Persistance;
using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Schm.Domain.Service
{
    public class ItemOptionService : BaseCrudService<ItemOption>, IItemOptionService
    {
        private IItemOptionRepository itemOptionRepository;
        public ItemOptionService(IItemOptionRepository repository) : base(repository)
        {
            itemOptionRepository = repository;
        }

        public async Task<List<ItemOption>> GetItemOption(int itemId)
        {
            return await itemOptionRepository.GetItemOption(itemId);
        }
    }
}
