using Entities;
using Services;
namespace Controllers;
public class OrderDetailController
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    public OrderDetailController(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public void Add(OrderDetail orderDetail)
    {
        _orderDetailRepository.Add(orderDetail);
    }

    public void Remove(long key)
    {
        _orderDetailRepository.Remove(key);
    }

    public OrderDetail Get(long key)
    {
        return _orderDetailRepository.Get(key);
    }

    public IEnumerable<OrderDetail> GetAll()
    {
        return _orderDetailRepository.GetAll();
    }

    public int Count()
    {
        return _orderDetailRepository.Count();
    }
}
