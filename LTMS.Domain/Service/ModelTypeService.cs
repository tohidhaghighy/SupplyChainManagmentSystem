using Framework.Persistance;
using LTMS.Domain.Service;
using Schm.Domain.IService;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Domain.Service
{
    public class ModelTypeService : BaseCrudService<ModelType>, IModelTypeService
    {
        public ModelTypeService(IRepository<ModelType> repository) : base(repository)
        {
        }
    }
}
