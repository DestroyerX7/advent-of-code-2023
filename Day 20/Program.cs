namespace Day_20;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 20/intput.txt");
        PartOne(lines);
        // PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        Dictionary<string, Module> moduleNameToModule = new();

        // Creating each module
        foreach (string line in lines)
        {
            if (line.StartsWith("%"))
            {
                string moduleName = line[1..line.IndexOf(' ')];
                FlipFlopModule flipFlopModule = new(moduleName);
                moduleNameToModule.Add(moduleName, flipFlopModule);
            }
            else if (line.StartsWith("&"))
            {
                string moduleName = line[1..line.IndexOf(' ')];
                ConjunctionModule conjunctionModule = new(moduleName);
                moduleNameToModule.Add(moduleName, conjunctionModule);
            }
            else
            {
                string moduleName = line[1..line.IndexOf(' ')];
                BroadcasterModule broadcasterModule = new(moduleName);
                moduleNameToModule.Add(moduleName, broadcasterModule);
            }
        }

        // Setting up destination modules
        foreach (string line in lines)
        {
            string moduleName = line[1..line.IndexOf(' ')];
            Module module = moduleNameToModule[moduleName];
            string[] destinationModuleNames = line[(line.IndexOf('>') + 2)..].Split(',').Select(n => n.Trim()).ToArray();

            foreach (string destinationModuleName in destinationModuleNames)
            {
                Module destinationModule = moduleNameToModule.ContainsKey(destinationModuleName) ? moduleNameToModule[destinationModuleName] : new(destinationModuleName);
                module.AddDestinationModule(destinationModule);
            }
        }

        for (int i = 0; i < 1000; i++)
        {
            moduleNameToModule["roadcaster"].RecievePulse(null, Pulse.Low);
        }

        Console.WriteLine("Part One : " + Module.TotalNumHighPulses * Module.TotalNumLowPulses);
    }

    private static void PartTwo(string[] lines)
    {
        Dictionary<string, Module> moduleNameToModule = new();

        // Creating each module
        foreach (string line in lines)
        {
            if (line.StartsWith("%"))
            {
                string moduleName = line[1..line.IndexOf(' ')];
                FlipFlopModule flipFlopModule = new(moduleName);
                moduleNameToModule.Add(moduleName, flipFlopModule);
            }
            else if (line.StartsWith("&"))
            {
                string moduleName = line[1..line.IndexOf(' ')];
                ConjunctionModule conjunctionModule = new(moduleName);
                moduleNameToModule.Add(moduleName, conjunctionModule);
            }
            else
            {
                string moduleName = line[1..line.IndexOf(' ')];
                BroadcasterModule broadcasterModule = new(moduleName);
                moduleNameToModule.Add(moduleName, broadcasterModule);
            }
        }

        // Setting up destination modules
        foreach (string line in lines)
        {
            string moduleName = line[1..line.IndexOf(' ')];
            Module module = moduleNameToModule[moduleName];
            string[] destinationModuleNames = line[(line.IndexOf('>') + 2)..].Split(',').Select(n => n.Trim()).ToArray();

            foreach (string destinationModuleName in destinationModuleNames)
            {
                Module destinationModule = moduleNameToModule.ContainsKey(destinationModuleName) ? moduleNameToModule[destinationModuleName] : new(destinationModuleName);
                module.AddDestinationModule(destinationModule);
            }
        }

        long count = 0;
        while (!Module.RxRecievedLow && count < 100000000)
        {
            moduleNameToModule["roadcaster"].RecievePulse(null, Pulse.Low);
            count++;
        }

        Console.WriteLine("Part Two : " + count);
    }
}
