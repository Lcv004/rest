namespace Processors;

public abstract class Processor : BaseThread
{
    private bool _isPaused = false;
    private bool _stopRequested = false;
    private int _interval = 500;

    public abstract void Process(int interval);
    public override void RunThread()
    {
        while (!_stopRequested)
        {
            if (!_isPaused)
            {
                Process(_interval);
            }
        }
    }

    public void PauseRequest() => _isPaused = true;
    public void Resume() => _isPaused = false;
    public void SetInterval(int interval) => _interval = interval;
    public void Stop() => _stopRequested = true;
}
