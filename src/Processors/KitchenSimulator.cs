namespace Processors;

public class KitchenSimulator : Processor
{
    public override void Process(int interval)
    {
        System.Console.WriteLine("~~> ¡Hola! son las {0}.", DateTime.Now.TimeOfDay);
        Thread.Sleep(interval);
    }
}
