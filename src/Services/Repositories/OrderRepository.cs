using Entities;
namespace Services;
public class OrderRepository : IOrderRepository
{
    private Dictionary<long, Order> _orderDictionary;
    private long _id;

    public OrderRepository()
    {
        _orderDictionary = new Dictionary<long, Order>();
        _id = 0;
    }

    public void Add(Order entity)
    {
        _id++;
        Order newOrder = entity with
        {
            Id = _id,
            CustomerId = entity.CustomerId,
            Status = entity.Status
        };
        _orderDictionary.Add(_id, newOrder);
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
