namespace Processors;

public class KitchenSimulator : Processor
{
    public override void Process(int interval)
    {
        System.Console.WriteLine("~~> ¡Hola! son las {0}.", DateTime.Now.TimeOfDay);
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

    public override void BeforeProcess()
    {
        // Not implemented
    }

    public override void AfterProcess()
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
