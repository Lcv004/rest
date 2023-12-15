namespace Processors;

public class Engine
{
    private readonly List<Processor> _processorList;
    public KitchenSimulator KS { get; set; }
    public Engine()
    {
        KS = new();
        _processorList = new()
        {
            KS
        };
    }

    public void Start()
    {
        foreach (var processor in _processorList)
        {
            processor.Start();
        }
    }
}
