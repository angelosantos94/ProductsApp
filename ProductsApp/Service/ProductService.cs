using ProductsApp.DataAccess.Context;
using ProductsApp.Interfaces;

namespace ProductsApp.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository) 
        {
            _repository = repository;
        }
        public Product GetProduct(string? productName)
        {
            return _repository.GetProduct(productName);
        }
    }
}
