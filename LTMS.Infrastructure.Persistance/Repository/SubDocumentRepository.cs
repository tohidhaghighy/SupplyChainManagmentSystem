using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class SubDocumentRepository : EFRepositoryBase<SchmDbContext, SubDocument>, ISubDocumentRepository
    {
        public SubDocumentRepository(SchmDbContext context) : base(context)
        {
        }

        public async Task<List<SubDocument>> GetSubDocumentwithItem(int documentId)
        {
            return _dbContext.Set<SubDocument>().Include(z => z.Item).Include(a => a.Document).Where(a => a.DocumentId == documentId).ToList();
        }
    }
}
