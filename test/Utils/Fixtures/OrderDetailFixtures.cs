using Entities;
namespace Utils.Test;

public class OrderDetailFixtures
{
    public static OrderDetail BuildOrderDetail(long id = 1, long orderId = 1, long productId = 1, uint quantity = 1)
    {
        var orderDetail = new OrderDetail(id, orderId, productId, quantity);
        return orderDetail;
    }

    public static List<OrderDetail> BuildOrderDetails(uint count)
    {
        var orderDetails = new List<OrderDetail>();
        for (var i = 1; i <= count; i++)
        {
            orderDetails.Add(BuildOrderDetail(i, i, i, (uint)i));
        }

        return orderDetails;
    }
}
