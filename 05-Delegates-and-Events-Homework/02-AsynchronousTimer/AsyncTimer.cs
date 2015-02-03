using System;
using System.Threading;

public class AsyncTimer
{
    private Action actionMethod;
    private int interval;
    private int ticks;

    public AsyncTimer(Action actionMethod, int interval, int ticks)
    {
        this.ticks = ticks;
        this.interval = interval;
        this.actionMethod = actionMethod;
    }

    private void SomeMethod()
    {
        while (this.ticks > 0)
        {
            Thread.Sleep(this.interval);

            if (actionMethod != null)
            {
                actionMethod();
            }

            this.ticks--;
        }
    }

    public void Start()
    {
        Thread thread = new Thread(this.SomeMethod);
        thread.Start();
    }

}
