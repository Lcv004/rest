using Services;
using Controllers;
namespace IoC;

public class Ioc
{
    private static Ioc? _instance;
    private static Dictionary<string, object> _iocInstanceDict = new Dictionary<string, object>();
    
    private Ioc()
    {
        _iocInstanceDict.Add("ProductRepository", new ProductRepository());
        _iocInstanceDict.Add("ProductController", new ProductController(
                            (ProductRepository)_iocInstanceDict["ProductRepository"]));
        
        _iocInstanceDict.Add("InventoryRepository", new InventoryRepository());
        _iocInstanceDict.Add("InventoryController", new InventoryController(
                            (InventoryRepository)_iocInstanceDict["InventoryRepository"]));

        _iocInstanceDict.Add("OrderRepository", new OrderRepository());
        _iocInstanceDict.Add("OrderController", new OrderController(
                            (OrderRepository)_iocInstanceDict["OrderRepository"]));

        _iocInstanceDict.Add("OrderDetailRepository", new OrderDetailRepository());
        _iocInstanceDict.Add("OrderDetailController", new OrderDetailController(
                            (OrderDetailRepository)_iocInstanceDict["OrderDetailRepository"]));

        _iocInstanceDict.Add("ChefRepository", new ChefRepository());
        _iocInstanceDict.Add("ChefController", new ChefController(
                            (ChefRepository)_iocInstanceDict["ChefRepository"]));
    }

    public static object Get(string key)
    {
        return _iocInstanceDict.TryGetValue(key, out object? outObj) ? outObj : throw new KeyNotFoundException($"Service was not found with key {key}.");
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
