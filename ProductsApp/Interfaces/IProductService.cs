using ProductsApp.DataAccess.Context;

namespace ProductsApp.Interfaces
{
    public interface IProductService
    {
        Product GetProduct(string? productName);
    }
}
