namespace Processors;

public class Engine
{
    private List<Processor> _processorList;
    public KitchenSimulator kitchenSimulator;
    public Engine()
    {
        kitchenSimulator = new KitchenSimulator();
        _processorList = new List<Processor>();

        _processorList.Add(kitchenSimulator);
    }

    public void Start()
    {
        foreach (var processor in _processorList)
        {
            processor.Start();
        }
    }
}
