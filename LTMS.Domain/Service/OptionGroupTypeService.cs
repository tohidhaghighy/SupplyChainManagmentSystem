using Framework.Persistance;
using LTMS.Domain.Service;
using Schm.Domain.IService;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Domain.Service
{
    public class OptionGroupTypeService : BaseCrudService<OptionGroupType>, IOptionGroupTypeService
    {
        public OptionGroupTypeService(IRepository<OptionGroupType> repository) : base(repository)
        {
        }
    }
}
