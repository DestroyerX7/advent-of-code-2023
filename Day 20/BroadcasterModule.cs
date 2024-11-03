namespace Day_20;

public class BroadcasterModule : Module
{
    public BroadcasterModule(string name) : base(name)
    {

    }

    public override void RecievePulse(Module? sender, Pulse pulse)
    {
        base.RecievePulse(sender, pulse);

        foreach (Module module in DestinationModules)
        {
            module.RecievePulse(this, pulse);
        }

        while (PulseQueue.Count > 0)
        {
            PulseQueue.Dequeue().Invoke();
        }
    }
}