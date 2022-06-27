namespace Processors;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Main: Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        Task kitchenTask = KitchenSimulator.StartAsync();
        bool flag = true;
        
        while (flag)
        {
            if(kitchenTask.IsCompleted)
            {
                Console.WriteLine("Completed!");
                flag = false;
            }
        }
        Console.ReadLine();
    }
}
