using Entities;
using Services;
namespace Controllers;
public class OrderController
{
    private readonly IOrderRepository _orderRepository;

    public OrderController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void Add(Order order)
    {
        _orderRepository.Add(order);
    }

    public void Remove(long key)
    {
        _orderRepository.Remove(key);
    }

    public Order Get(long key)
    {
        return _orderRepository.Get(key);
    }

    public IEnumerable<Order> GetAll()
    {
        return _orderRepository.GetAll();
    }

    public int Count()
    {
        return _orderRepository.Count();
    }
}
