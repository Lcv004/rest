namespace Processors;

public abstract class Processor : BaseThread
{    
    private bool _pauseRequest = false;
    private bool _resumeRequest = false;
    private bool _stopRequest = false;
    private int _interval = 500;
    public ProcessState State { get; private set; }

    protected Processor()
    {
        State = ProcessState.Created;
        OnCreate();
    }

    public abstract void OnCreate();
    public abstract void OnStart();
    public abstract void OnStop();
    public abstract void OnPause();
    public abstract void OnResume();
    public abstract void Process(int interval);
    public override void RunThread()
    {
        State = ProcessState.Starting;
        OnStart();

        State = ProcessState.Processing;
        while (!_stopRequest)
        {
            if (State == ProcessState.Processing && _pauseRequest)
            {
                State = ProcessState.Paused;
                _pauseRequest = false;
                OnPause();
            }
            else if (State == ProcessState.Paused && _resumeRequest)
            {
                State = ProcessState.Processing;
                _resumeRequest = false;
                OnResume();
            }

            if (State == ProcessState.Processing)
            {
                Process(_interval);
            }
        }

        State = ProcessState.Stopping;
        OnStop();
    }

    public void Pause() => _pauseRequest = true;
    public void Resume() => _resumeRequest = true;
    public void Stop() => _stopRequest = true;
    public void SetInterval(int interval) => _interval = interval;
}
