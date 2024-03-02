using ProductsApp.DataAccess.Context;
using ProductsApp.Interfaces;

namespace ProductsApp.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void SaveTransactions(List<Transaction> transactions)
        {
            _transactionRepository.SaveTransactions(transactions);
        }
    }
}
