using Entities;
namespace Utils.Test;

public class OrderFixtures
{
    public static Order BuildOrder(long id = 1, long customerId = 1, string status = "Pending")
    {
        var order = new Order(id, customerId, status);
        return order;
    }

    public static List<Order> BuildOrders(uint count)
    {
        var orders = new List<Order>();
        for (var i = 1; i <= count; i++)
        {
            orders.Add(BuildOrder(i, i, "Pending"));
        }

        return orders;
    }
}
