namespace Day_20;

public class ConjunctionModule : Module
{
    private Dictionary<Module, Pulse> _inputModuleToLastPulseRecieved = new();

    public ConjunctionModule(string name) : base(name)
    {

    }

    public override void RecievePulse(Module? sender, Pulse pulse)
    {
        base.RecievePulse(sender, pulse);

        if (sender == null)
        {
            return;
        }

        _inputModuleToLastPulseRecieved[sender] = pulse;

        Pulse pulseToSend = _inputModuleToLastPulseRecieved.Values.All(v => v == Pulse.High) ? Pulse.Low : Pulse.High;

        foreach (Module module in DestinationModules)
        {
            PulseQueue.Enqueue(() => module.RecievePulse(this, pulseToSend));
        }
    }

    public void AddInputModule(Module inputModule)
    {
        _inputModuleToLastPulseRecieved.Add(inputModule, Pulse.Low);
    }
}