using System.Collections.Generic;
using System.Linq;
using Entities;
using Utils.Test;
using Xunit;
namespace Services.Test;

public class OrderRepositoryTest
{
    [Fact]
    public void Add_OneOrder_ShouldCountOneOrder()
    {
        var orderRepository = new OrderRepository();
        var order = OrderFixtures.BuildOrder();
        orderRepository.Add(order);

        Assert.Equal(1, orderRepository.Count());
    }

    [Fact]
    public void Remove_OneOrder_ShouldCountOneOrders()
    {
        var orderRepository = new OrderRepository();
        var orders = OrderFixtures.BuildOrders(2);
        orderRepository.Add(orders[0]);
        orderRepository.Add(orders[1]);

        orderRepository.Remove(1);

        Assert.Equal(1, orderRepository.Count());
    }

    [Fact]
    public void Get_OneOrder_ShouldReturnOneOrder()
    {
        var orderRepository = new OrderRepository();
        var order = OrderFixtures.BuildOrder();
        orderRepository.Add(order);

        var result = orderRepository.Get(1);

        Assert.Equal(order, result);
    }

    [Fact]
    public void Get_NoOrder_ShouldReturnKeyNotFoundException()
    {
        var orderRepository = new OrderRepository();

        Assert.Throws<KeyNotFoundException>(() => orderRepository.Get(2));
    }

    [Fact]
    public void GetAll_Orders_ShouldReturnThreeOrders()
    {
        var orderRepository = new OrderRepository();
        var orders = OrderFixtures.BuildOrders(3);
        orderRepository.Add(orders[0]);
        orderRepository.Add(orders[1]);
        orderRepository.Add(orders[2]);

        var result = orderRepository.GetAll();

        Assert.Equal(orders.Count(), result.Count());
        Assert.Equal<Order>(orders, result);
    }
}
