using Controllers;
using Services;
namespace IoC;

public class Ioc
{
    private static Ioc? _instance;
    private static readonly Dictionary<string, object> _iocInstanceDict = new Dictionary<string, object>();

    private Ioc()
    {
        _iocInstanceDict.Add("ProductRepository", new ProductRepository());
        _iocInstanceDict.Add("ProductController", new ProductController(
                            (ProductRepository)_iocInstanceDict["ProductRepository"]));
    }

    public static object Get(string key)
    {
        return _iocInstanceDict.TryGetValue(key, out var outObj) ? outObj : throw new KeyNotFoundException($"Service was not found with key {key}.");
    }

    public static Ioc GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Ioc();
        }

        return _instance;
    }
}
