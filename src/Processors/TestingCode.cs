namespace Processors;

internal class Test
{
    static void Main(string[] args)
    {
        Engine engine = new Engine();
        engine.kitchenSimulator.SetInterval(2000);

        System.Console.WriteLine("Iniciando a las {0}.", DateTime.Now.TimeOfDay);
        engine.Start();
        Thread.Sleep(10000);

        System.Console.WriteLine("Pausando por 10s a las {0}.", DateTime.Now.TimeOfDay);
        engine.kitchenSimulator.PauseRequest();
        Thread.Sleep(10000);

        System.Console.WriteLine("Reiniciando a las {0}.", DateTime.Now.TimeOfDay);
        engine.kitchenSimulator.Resume();
        Thread.Sleep(6000);

        engine.kitchenSimulator.Stop();
        System.Console.WriteLine("Terminando luego de 26s a las {0}.", DateTime.Now.TimeOfDay);
    }
}
