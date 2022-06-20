using System.Collections.Generic;
using System.Linq;
using Entities;
using Utils.Test;
using Xunit;
namespace Services.Test;

public class OrderDetailRepositoryTest
{
    [Fact]
    public void Add_OneOrderDetail_ShouldCountOneOrderDetail()
    {
        var orderDetailRepository = new OrderDetailRepository();
        var orderDetail = OrderDetailFixtures.BuildOrderDetail();
        orderDetailRepository.Add(orderDetail);

        Assert.Equal(1, orderDetailRepository.Count());
    }

    [Fact]
    public void Remove_OneOrderDetail_ShouldCountOneOrderDetails()
    {
        var orderDetailRepository = new OrderDetailRepository();
        var orderDetails = OrderDetailFixtures.BuildOrderDetails(2);
        orderDetailRepository.Add(orderDetails[0]);
        orderDetailRepository.Add(orderDetails[1]);

        orderDetailRepository.Remove(1);

        Assert.Equal(1, orderDetailRepository.Count());
    }

    [Fact]
    public void Get_OneOrderDetail_ShouldReturnOneOrderDetail()
    {
        var orderDetailRepository = new OrderDetailRepository();
        var orderDetail = OrderDetailFixtures.BuildOrderDetail();
        orderDetailRepository.Add(orderDetail);

        var result = orderDetailRepository.Get(1);

        Assert.Equal(orderDetail, result);
    }

    [Fact]
    public void Get_NoOrderDetail_ShouldReturnKeyNotFoundException()
    {
        var orderDetailRepository = new OrderDetailRepository();

        Assert.Throws<KeyNotFoundException>(() => orderDetailRepository.Get(2));
    }

    [Fact]
    public void GetAll_OrderDetails_ShouldReturnThreeOrderDetails()
    {
        var orderDetailRepository = new OrderDetailRepository();
        var orderDetails = OrderDetailFixtures.BuildOrderDetails(3);
        orderDetailRepository.Add(orderDetails[0]);
        orderDetailRepository.Add(orderDetails[1]);
        orderDetailRepository.Add(orderDetails[2]);

        var result = orderDetailRepository.GetAll();

        Assert.Equal(orderDetails.Count(), result.Count());
        Assert.Equal<OrderDetail>(orderDetails, result);
    }
}
