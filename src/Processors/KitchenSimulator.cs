namespace Processors;

public class KitchenSimulator : Processor
{
    public override void Process(int interval)
    {
        Console.WriteLine("~~> KS running.");
        Thread.Sleep(interval);
    }

    public override void OnCreate()
    {
        // Not implemented
    }

    public override void OnStart()
    {
        // Not implemented
    }

    public override void OnPause()
    {
        // Not implemented
    }
    public override void OnResume()
    {
        // Not implemented
    }

    public override void OnStop()
    {
        // Not implemented
    }
}
