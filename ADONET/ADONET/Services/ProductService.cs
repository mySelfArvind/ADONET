using ADONET.DTO;
using ADONET.Repositories;

namespace ADONET.Services
{
    public class ProductService
    {
        ProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public List<ProductDTO> SearchProductWithName(string productName)
        {
            return _productRepository.SearchProductWithName(productName);
        }

        public List<ProductDTO> SearchProductWithNameUsingParameterizedQuery(string productName)
        {
            return _productRepository.SearchProductWithNameUsingParameterizedQuery(productName);
        }

        public List<ProductDTO> SearchProductWithNameUsingStoredProcedure(string productName)
        {
            return _productRepository.SearchProductWithNameUsingStoredProcedure(productName);
        }
    }
}
