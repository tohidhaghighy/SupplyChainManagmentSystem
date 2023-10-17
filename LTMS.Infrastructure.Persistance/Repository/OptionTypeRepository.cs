using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class OptionTypeRepository : EFRepositoryBase<SchmDbContext, OptionType>, IOptionTypeRepository
    {
        public OptionTypeRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
