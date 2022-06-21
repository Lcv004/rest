using Entities;
namespace Services;
public class ProductRepository : IProductRepository
{
    private readonly Dictionary<long, Product> _productDictionary;
    private long _id;

    public ProductRepository()
    {
        _productDictionary = new Dictionary<long, Product>();
        _id = 0;
    }

    public void Add(Product entity)
    {
        _id++;
        entity.Id = _id;
        _productDictionary.Add(_id, entity);
    }

    public void Remove(long key)
    {
        if (_productDictionary.ContainsKey(key))
        {
            _productDictionary.Remove(key);
            // TODO: Change product status to "removed".
        }
    }

    public Product Get(long key)
    {
        return _productDictionary[key];
    }

    public IEnumerable<Product> GetAll()
    {
        return _productDictionary.Values;
    }

    public int Count()
    {
        return _productDictionary.Count;
    }
}
