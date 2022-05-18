using Entities;
using Services;
namespace Controllers;
public class ProductController
{
    private IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void Add(Product product)
    {
        _productRepository.Add(product);
    }

    public void Remove(long key)
    {
        _productRepository.Remove(key);
    }

    public Product Get(long key)
    {
        return _productRepository.Get(key);
    }

    public IEnumerable<Product> GetAll()
    {
        return _productRepository.GetAll();
    }

    public int Count()
    {
        return _productRepository.Count();
    }
}
