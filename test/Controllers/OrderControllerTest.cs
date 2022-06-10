using Xunit;
using Moq;
using Services;
using Entities;
using Utils.Test;
namespace Controllers.Test;

public class OrderControllerTest
{
    private Mock<IOrderRepository> _mockOrderRepo;

    public OrderControllerTest()
    {
        _mockOrderRepo = new Mock<IOrderRepository>();
    }

    [Fact]
    public void Add_OneOrder_VerifyAddCallOnce()
    {
        // Given
        var order = OrderFixtures.BuildOrder();
        _mockOrderRepo.Setup(m => m.Add(It.IsAny<Order>())).Verifiable();
        var orderController = new OrderController(_mockOrderRepo.Object);

        // When
        orderController.Add(order);

        // Then
        _mockOrderRepo.Verify(m => m.Add(It.IsAny<Order>()), Times.Once);
    }

    [Fact]
    public void Remove_OneOrder_VerifyRemoveCallOnce()
    {
        // Given
        _mockOrderRepo.Setup(m => m.Remove(It.IsAny<long>())).Verifiable();
        var orderController = new OrderController(_mockOrderRepo.Object);

        // When
        orderController.Remove(1);

        // Then
        _mockOrderRepo.Verify(m => m.Remove(It.IsAny<long>()), Times.Once);
    }

    [Fact]
    public void Get_OneOrder_VerifyGetCall()
    {
        // Given
        var order = OrderFixtures.BuildOrder();
        _mockOrderRepo.Setup(m => m.Get(It.IsAny<long>()))
        .Returns(order)
        .Verifiable();

        var orderController = new OrderController(_mockOrderRepo.Object);

        // When
        var result = orderController.Get(1);

        // Then
        Assert.Equal<Order>(order, result);
        _mockOrderRepo.Verify();
    }

    [Fact]
    public void GetAll_Orders_VerifyGetAllCall()
    {
        // Given
        var orders = OrderFixtures.BuildOrders(3);
        _mockOrderRepo.Setup(m => m.GetAll())
        .Returns(orders)
        .Verifiable();

        var orderController = new OrderController(_mockOrderRepo.Object);

        // When
        var result = orderController.GetAll();

        // Then
        Assert.Equal<Order>(orders, result);
        _mockOrderRepo.Verify();
    }

    [Fact]
    public void Count_ThreeOrders_VerifyCountCall()
    {
        // Given
        _mockOrderRepo.Setup(m => m.Count())
        .Returns(3)
        .Verifiable();

        var orderController = new OrderController(_mockOrderRepo.Object);

        // When
        var result = orderController.Count();

        // Then
        Assert.Equal(3, result);
        _mockOrderRepo.Verify();
    }
}
