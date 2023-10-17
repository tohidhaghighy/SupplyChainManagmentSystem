using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class ModelTypeRepository : EFRepositoryBase<SchmDbContext, ModelType>, IModelTypeRepository
    {
        public ModelTypeRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
