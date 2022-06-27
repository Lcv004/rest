using Controllers;
using IoC;
using Utils.Test;
namespace Seed;

public class InitialData
{
    public static void Main(string[] args)
    {
        Ioc.GetInstance();
        var orderController = (OrderController)Ioc.Get("OrderController");
        orderController.Add(OrderFixtures.BuildOrder());
        orderController.Add(OrderFixtures.BuildOrder(2, 1, "Ready"));
    }
}
