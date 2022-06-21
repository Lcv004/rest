using Entities;
namespace Services;
public class OrderRepository : IOrderRepository
{
    private readonly Dictionary<long, Order> _orderDictionary;
    private long _id;

    public OrderRepository()
    {
        _orderDictionary = new Dictionary<long, Order>();
        _id = 0;
    }

    public void Add(Order entity)
    {
        _id++;
        entity.Id = _id;
        _orderDictionary.Add(_id, entity);
    }

    public void Remove(long key)
    {
        if (_orderDictionary.ContainsKey(key))
        {
            _orderDictionary.Remove(key);
            // TODO: Change order status to "removed".
        }
    }

    public Order Get(long key)
    {
        return _orderDictionary[key];
    }

    public IEnumerable<Order> GetAll()
    {
        return _orderDictionary.Values;
    }

    public int Count()
    {
        return _orderDictionary.Count;
    }
}
