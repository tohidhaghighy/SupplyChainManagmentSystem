using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class OptionGroupTypeRepository : EFRepositoryBase<SchmDbContext, OptionGroupType>, IOptionGroupTypeRepository
    {
        public OptionGroupTypeRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
