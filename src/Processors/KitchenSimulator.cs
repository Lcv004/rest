namespace Processors;

public class KitchenSimulator
{
    public static async Task StartAsync()
    {
        Console.WriteLine($"-->KS: Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        Task<bool> prepareOrder1 = PrepareOrder(5000);
        Task<bool> prepareOrder2 = PrepareOrder(2000);
        Task<bool> prepareOrder3 = PrepareOrder(7000);
        List<Task<bool>> prepareOrderList = new List<Task<bool>>{prepareOrder1, prepareOrder2, prepareOrder3};
        await Task.WhenAll(prepareOrderList);        
        Console.WriteLine("-->KS: Order ready!");
    }

    public static async Task<bool> PrepareOrder(int preparationTime)
    {
        Console.WriteLine($"---->Task: Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        var task = Task<bool>.Run(()=>
        {
            Console.WriteLine("---->Task: Doing some work...");
            Thread.Sleep(preparationTime);
            Console.WriteLine("---->Task: Work finished!");
            return true;
        });

        bool result = await task;
        return result;
    }
}
