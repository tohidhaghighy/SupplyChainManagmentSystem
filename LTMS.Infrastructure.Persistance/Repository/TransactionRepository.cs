using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class TransactionRepository : EFRepositoryBase<SchmDbContext, Transaction>, ITransactionRepository
    {
        public TransactionRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
