namespace Processors;

public abstract class Processor : BaseThread
{
    private bool _isPaused = false;
    private bool _onPauseOnce = false;
    private bool _onResumeOnce = false;
    private bool _stopRequested = false;
    private int _interval = 500;

    protected Processor()
    {
        OnCreate();
    }

    public abstract void OnCreate();
    public abstract void OnStart();
    public abstract void OnStop();
    public abstract void OnPause();
    public abstract void OnResume();
    public abstract void BeforeProcess();
    public abstract void Process(int interval);
    public abstract void AfterProcess(); 
    public override void RunThread()
    {
        OnStart();

        while (!_stopRequested)
        {
            if (!_isPaused)
            {
                if (!_onResumeOnce && _onPauseOnce)
                {
                    OnResume();
                }
                _onPauseOnce = false;

                Process(_interval);
            }
            else
            {
                if (!_onPauseOnce)
                {
                    OnPause();
                    _onPauseOnce = true;
                }
                _onResumeOnce = false;
            }
        }

        OnStop();
    }

    public void PauseRequest() => _isPaused = true;
    public void Resume() => _isPaused = false;
    public void SetInterval(int interval) => _interval = interval;
    public void Stop() => _stopRequested = true;
}
