using LTMS.Domain.Service;
using Schm.Domain.IRepositroy;
using Schm.Domain.IService;
using Schm.Domain.Model;

namespace Schm.Domain.Service
{
    public class TransactionService : BaseCrudService<Transaction>, ITransactionService
    {
        private ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository repository) : base(repository)
        {
            _transactionRepository = repository;
        }
    }
}
