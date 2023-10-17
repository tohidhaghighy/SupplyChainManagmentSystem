using Framework.Persistance;
using LTMS.Domain.Service;
using Schm.Domain.IService;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Domain.Service
{
    public class ItemUnitTypeService : BaseCrudService<ItemUnitType>, IItemUnitTypeService
    {
        public ItemUnitTypeService(IRepository<ItemUnitType> repository) : base(repository)
        {
        }
    }
}
