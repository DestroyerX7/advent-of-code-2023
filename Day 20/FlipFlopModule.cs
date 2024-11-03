namespace Day_20;

public class FlipFlopModule : Module
{
    private bool _isOn;

    public FlipFlopModule(string name) : base(name)
    {

    }

    public override void RecievePulse(Module? sender, Pulse pulse)
    {
        base.RecievePulse(sender, pulse);

        if (pulse == Pulse.High)
        {
            return;
        }

        Pulse pulseToSend = _isOn ? Pulse.Low : Pulse.High;

        foreach (Module module in DestinationModules)
        {
            PulseQueue.Enqueue(() => module.RecievePulse(this, pulseToSend));
        }

        _isOn = !_isOn;
    }
}