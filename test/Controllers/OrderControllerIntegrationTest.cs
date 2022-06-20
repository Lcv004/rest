using Entities;
using FakeItEasy;
using Services;
using Utils.Test;
using Xunit;
namespace Controllers.Test;

public class OrderControllerIntegrationTest
{
    [Fact]
    public void Add_OneOrder_ShouldReturnOrderIdIncrementAndVerifyAddCallOnce()
    {
        // Given
        var order = OrderFixtures.BuildOrder(0);
        var orderRepository = new OrderRepository();
        var mockOrderRepo = A.Fake<IOrderRepository>(x => x.Wrapping(orderRepository));
        var orderController = new OrderController(mockOrderRepo);

        // When
        Assert.Equal(0, mockOrderRepo.Count());
        orderController.Add(order);

        //Then
        Assert.Equal(1, mockOrderRepo.Get(1).Id);
        A.CallTo(() => mockOrderRepo.Add(order)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void Remove_OneOrder_ShouldReturnOrderCountDecreasedAndVerifyRemoveCallOnce()
    {
        // Given
        var order = OrderFixtures.BuildOrders(2);
        var orderRepository = new OrderRepository();
        var mockOrderRepo = A.Fake<IOrderRepository>(x => x.Wrapping(orderRepository));
        var orderController = new OrderController(mockOrderRepo);
        orderController.Add(order[0]);
        orderController.Add(order[1]);

        // When
        Assert.Equal(2, mockOrderRepo.Count());
        orderController.Remove(1);

        // Then
        A.CallTo(() => mockOrderRepo.Remove(1)).MustHaveHappenedOnceExactly();
        Assert.Equal(1, mockOrderRepo.Count());
    }

    [Fact]
    public void Get_OneOrder_ShouldReturnOrderAndVerifyGetCall()
    {
        // Given
        var order = OrderFixtures.BuildOrder();
        var orderRepository = new OrderRepository();
        var mockOrderRepo = A.Fake<IOrderRepository>(x => x.Wrapping(orderRepository));
        var orderController = new OrderController(mockOrderRepo);
        orderController.Add(order);

        // When
        var result = orderController.Get(1);

        // Then
        Assert.Equal<Order>(order, result);
        A.CallTo(() => mockOrderRepo.Get(1)).MustHaveHappened();
    }

    [Fact]
    public void GetAll_Orders_ShouldReturnOrdersAndVerifyGetAllCall()
    {
        // Given
        var orders = OrderFixtures.BuildOrders(3);
        var orderRepository = new OrderRepository();
        var mockOrderRepo = A.Fake<IOrderRepository>(x => x.Wrapping(orderRepository));
        var orderController = new OrderController(mockOrderRepo);
        orderController.Add(orders[0]);
        orderController.Add(orders[1]);
        orderController.Add(orders[2]);

        // When
        var result = orderController.GetAll();

        // Then
        Assert.Equal<Order>(orders, result);
        A.CallTo(() => mockOrderRepo.GetAll()).MustHaveHappened();
    }
}
