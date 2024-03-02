using ProductsApp.DataAccess.Context;

namespace ProductsApp.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(string? productName);
    }
}
