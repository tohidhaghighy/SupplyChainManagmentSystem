﻿using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class LogesticTypeRepository : EFRepositoryBase<SchmDbContext, LogesticType>, ILogesticTypeRepository
    {
        public LogesticTypeRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
