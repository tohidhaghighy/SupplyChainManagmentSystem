﻿using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class DocumentRepository : EFRepositoryBase<SchmDbContext, Document>, IDocumentRepository
    {
        public DocumentRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
