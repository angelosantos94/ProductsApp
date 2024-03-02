using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductsApp.DataAccess.Context;
using ProductsApp.Interfaces;

namespace ProductsApp.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ProductRepository(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public Product GetProduct(string? productName)
        {
            var parameter = new SqlParameter("@ProductName", productName);
            return _dbContext.Products.FromSqlRaw($"EXECUTE dbo.GetProducts @ProductName", parameter).AsEnumerable().SingleOrDefault();
        }
    }
}
