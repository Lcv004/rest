using Entities;
using Moq;
using Services;
using Utils.Test;
using Xunit;
namespace Controllers.Test;

public class OrderDetailControllerTest
{
    private readonly Mock<IOrderDetailRepository> _mockOrderDetailRepo;

    public OrderDetailControllerTest()
    {
        _mockOrderDetailRepo = new Mock<IOrderDetailRepository>();
    }

    [Fact]
    public void Add_OneOrderDetail_VerifyAddCallOnce()
    {
        // Given
        var orderDetail = OrderDetailFixtures.BuildOrderDetail();
        _mockOrderDetailRepo.Setup(m => m.Add(It.IsAny<OrderDetail>())).Verifiable();
        var orderDetailController = new OrderDetailController(_mockOrderDetailRepo.Object);

        // When
        orderDetailController.Add(orderDetail);

        // Then
        _mockOrderDetailRepo.Verify(m => m.Add(It.IsAny<OrderDetail>()), Times.Once);
    }

    [Fact]
    public void Remove_OneOrderDetail_VerifyRemoveCallOnce()
    {
        // Given
        _mockOrderDetailRepo.Setup(m => m.Remove(It.IsAny<long>())).Verifiable();
        var orderDetailController = new OrderDetailController(_mockOrderDetailRepo.Object);

        // When
        orderDetailController.Remove(1);

        // Then
        _mockOrderDetailRepo.Verify(m => m.Remove(It.IsAny<long>()), Times.Once);
    }

    [Fact]
    public void Get_OneOrderDetail_VerifyGetCall()
    {
        // Given
        var orderDetail = OrderDetailFixtures.BuildOrderDetail();
        _mockOrderDetailRepo.Setup(m => m.Get(It.IsAny<long>()))
        .Returns(orderDetail)
        .Verifiable();

        var orderDetailController = new OrderDetailController(_mockOrderDetailRepo.Object);

        // When
        var result = orderDetailController.Get(1);

        // Then
        Assert.Equal<OrderDetail>(orderDetail, result);
        _mockOrderDetailRepo.Verify();
    }

    [Fact]
    public void GetAll_OrderDetails_VerifyGetAllCall()
    {
        // Given
        var orderDetails = OrderDetailFixtures.BuildOrderDetails(3);
        _mockOrderDetailRepo.Setup(m => m.GetAll())
        .Returns(orderDetails)
        .Verifiable();

        var orderDetailController = new OrderDetailController(_mockOrderDetailRepo.Object);

        // When
        var result = orderDetailController.GetAll();

        // Then
        Assert.Equal<OrderDetail>(orderDetails, result);
        _mockOrderDetailRepo.Verify();
    }

    [Fact]
    public void Count_ThreeOrderDetails_VerifyCountCall()
    {
        // Given
        _mockOrderDetailRepo.Setup(m => m.Count())
        .Returns(3)
        .Verifiable();

        var orderDetailController = new OrderDetailController(_mockOrderDetailRepo.Object);

        // When
        var result = orderDetailController.Count();

        // Then
        Assert.Equal(3, result);
        _mockOrderDetailRepo.Verify();
    }
}
