namespace Day_20;

public class Module
{
    public string Name { get; protected set; }
    protected readonly List<Module> DestinationModules = new();
    protected static readonly Queue<Action> PulseQueue = new();

    public static int TotalNumHighPulses { get; private set; }
    public static int TotalNumLowPulses { get; private set; }
    public static bool RxRecievedLow { get; private set; }

    public Module(string name)
    {
        Name = name;
    }

    public void AddDestinationModule(Module module)
    {
        DestinationModules.Add(module);

        if (module.GetType() == typeof(ConjunctionModule))
        {
            ((ConjunctionModule)module).AddInputModule(this);
        }
    }

    public virtual void RecievePulse(Module? sender, Pulse pulse)
    {
        // System.Console.WriteLine(sender + " " + pulse + " -> " + this);
        if (Name == "rx" && pulse == Pulse.Low)
        {
            RxRecievedLow = true;
        }

        if (pulse == Pulse.High)
        {
            TotalNumHighPulses++;
        }
        else
        {
            TotalNumLowPulses++;
        }
    }

    public override string ToString()
    {
        return Name;
    }
}

public enum Pulse
{
    High,
    Low,
}