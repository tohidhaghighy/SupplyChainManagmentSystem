using Framework.Persistance;
using LTMS.Domain.Service;
using Schm.Domain.IService;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Domain.Service
{
    public class BrandTypeService : BaseCrudService<BrandType>, IBrandTypeService
    {
        public BrandTypeService(IRepository<BrandType> repository) : base(repository)
        {
        }
    }
}
