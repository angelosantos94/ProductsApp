using ProductsApp.DataAccess.Context;

namespace ProductsApp.Interfaces
{
    public interface ITransactionService
    {
        void SaveTransactions(List<Transaction> transactions);
    }
}
