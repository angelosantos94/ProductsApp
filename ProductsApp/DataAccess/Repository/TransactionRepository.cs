using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductsApp.DataAccess.Context;
using ProductsApp.Interfaces;
using System.Data;

namespace ProductsApp.DataAccess.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public TransactionRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveTransactions(List<Transaction> transactions)
        {
            try
            {
                var dataTable = ConvertToDataTable(transactions);

                var parameter = new SqlParameter
                {
                    ParameterName = "@Transactions",
                    SqlDbType = System.Data.SqlDbType.Structured,
                    TypeName = "dbo.TransactionTableType",
                    Value = dataTable
                };

                _dbContext.Database.ExecuteSqlRaw("EXEC dbo.InsertMultipleTransactions @Transactions", parameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private DataTable ConvertToDataTable(List<Transaction> transactions)
        {
            try
            {
                var dataTable = new DataTable();

                // Add columns to the DataTable
                dataTable.Columns.Add("TransactionId", typeof(string));
                dataTable.Columns.Add("ProductId", typeof(int));
                dataTable.Columns.Add("Cost", typeof(decimal));
                dataTable.Columns.Add("Quantity", typeof(int));
                dataTable.Columns.Add("Amount", typeof(decimal));
                dataTable.Columns.Add("TotalAmount", typeof(decimal));
                dataTable.Columns.Add("Cash", typeof(decimal));
                dataTable.Columns.Add("Change", typeof(decimal));

                // Add rows to the DataTable
                foreach (var transaction in transactions)
                {
                    dataTable.Rows.Add(transaction.TransactionId, transaction.ProductId, transaction.Cost, transaction.Quantity, transaction.Amount, transaction.TotalAmount, transaction.Cash, transaction.Change);
                }

                return dataTable;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
