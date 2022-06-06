using Xunit;
using FakeItEasy;
using Services;
using Entities;
using Utils.Test;
namespace Controllers.Test;

public class OrderDetailControllerIntegrationTest
{
    private OrderDetailRepository _orderDetailRepository;
    private IOrderDetailRepository _mockOrderDetailRepo;

    public OrderDetailControllerIntegrationTest()
    {
        _orderDetailRepository = new OrderDetailRepository();
        _mockOrderDetailRepo = A.Fake<IOrderDetailRepository>(x => x.Wrapping(_orderDetailRepository));
    }

    [Fact]
    public void Add_OneOrderDetail_ShouldReturnOrderDetailIdIncrementAndVerifyAddCallOnce()
    {
        // Given
        var orderDetail = OrderDetailFixtures.BuildOrderDetail(0);
        var orderDetailController = new OrderDetailController(_mockOrderDetailRepo);

        // When
        Assert.Equal(0, _mockOrderDetailRepo.Count());
        orderDetailController.Add(orderDetail);

        //Then
        Assert.Equal(1, _mockOrderDetailRepo.Get(1).Id);
        A.CallTo(() => _mockOrderDetailRepo.Add(orderDetail)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void Remove_OneOrderDetail_ShouldReturnOrderDetailCountDecreasedAndVerifyRemoveCallOnce()
    {
        // Given
        var orderDetail = OrderDetailFixtures.BuildOrderDetails(2);
        var orderDetailController = new OrderDetailController(_mockOrderDetailRepo);
        orderDetailController.Add(orderDetail[0]);
        orderDetailController.Add(orderDetail[1]);

        // When
        Assert.Equal(2, _mockOrderDetailRepo.Count());
        orderDetailController.Remove(1);

        // Then
        A.CallTo(() => _mockOrderDetailRepo.Remove(1)).MustHaveHappenedOnceExactly();
        Assert.Equal(1, _mockOrderDetailRepo.Count());
    }

    [Fact]
    public void Get_OneOrderDetail_ShouldReturnOrderDetailAndVerifyGetCall()
    {
        // Given
        var orderDetail = OrderDetailFixtures.BuildOrderDetail();
        var orderDetailController = new OrderDetailController(_mockOrderDetailRepo);
        orderDetailController.Add(orderDetail);

        // When
        var result = orderDetailController.Get(1);

        // Then
        Assert.Equal<OrderDetail>(orderDetail, result);
        A.CallTo(() => _mockOrderDetailRepo.Get(1)).MustHaveHappened();
    }

    [Fact]
    public void GetAll_OrderDetails_ShouldReturnOrderDetailsAndVerifyGetAllCall()
    {
        // Given
        var orderDetails = OrderDetailFixtures.BuildOrderDetails(3);
        var orderDetailController = new OrderDetailController(_mockOrderDetailRepo);
        orderDetailController.Add(orderDetails[0]);
        orderDetailController.Add(orderDetails[1]);
        orderDetailController.Add(orderDetails[2]);

        // When
        var result = orderDetailController.GetAll();

        // Then
        Assert.Equal<OrderDetail>(orderDetails, result);
        A.CallTo(() => _mockOrderDetailRepo.GetAll()).MustHaveHappened();
    }
}
