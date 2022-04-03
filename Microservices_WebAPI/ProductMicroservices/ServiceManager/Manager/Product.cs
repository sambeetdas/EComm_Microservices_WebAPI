using DataAccess.IRepository;
using Model;
using ServiceManager.IManager;

namespace ServiceManager.Manager
{
    public class Product : IProduct
    {
        private readonly IProductRepository _productRepository;
        public Product(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductModel ProcessProduct(ProductModel product)
        {
            dynamic result = _productRepository.ProcessProduct(product);
            return result;
        }

        public ProductModel GetProductBySku(string sku)
        {
            dynamic result = _productRepository.GetProductBySku(sku);
            return result;
        }

       
    }
}
