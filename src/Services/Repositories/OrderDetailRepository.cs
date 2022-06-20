using Entities;
namespace Services;
public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly Dictionary<long, OrderDetail> _orderDetailDictionary;
    private long _id;

    public OrderDetailRepository()
    {
        _orderDetailDictionary = new Dictionary<long, OrderDetail>();
        _id = 0;
    }

    public void Add(OrderDetail entity)
    {
        _id++;
        entity.Id = _id;
        _orderDetailDictionary.Add(_id, entity);
    }

    public void Remove(long key)
    {
        if (_orderDetailDictionary.ContainsKey(key))
        {
            _orderDetailDictionary.Remove(key);
            // TODO: Change orderDetail status to "removed".
        }
    }

    public OrderDetail Get(long key)
    {
        return _orderDetailDictionary[key];
    }

    public IEnumerable<OrderDetail> GetAll()
    {
        return _orderDetailDictionary.Values;
    }

    public int Count()
    {
        return _orderDetailDictionary.Count;
    }
}
