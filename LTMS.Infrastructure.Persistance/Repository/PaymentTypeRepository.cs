using Framework.Persistance;
using LTMS.Infrastructure.Persistance;
using Schm.Domain.IRepositroy;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.Repository
{
    public class PaymentTypeRepository : EFRepositoryBase<SchmDbContext, PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(SchmDbContext context) : base(context)
        {
        }
    }
}
