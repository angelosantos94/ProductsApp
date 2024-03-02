using ProductsApp.DataAccess.Context;

namespace ProductsApp.Interfaces
{
    public interface ITransactionRepository
    {
        void SaveTransactions(List<Transaction> transactions);
    }
}
