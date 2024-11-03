namespace Day_19;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 19/input.txt");
        PartOne(lines);
        // PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        Dictionary<string, Workflow> workflows = new();
        List<MachinePart> machineParts = new();

        bool inMachineParts = false;

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                inMachineParts = true;
                continue;
            }

            if (!inMachineParts)
            {
                string workflowName = line[..line.IndexOf('{')];
                string rules = line[(line.IndexOf('{') + 1)..line.IndexOf('}')];
                Workflow workflow = new(workflowName, rules);
                workflows.Add(workflowName, workflow);
            }
            else
            {
                string[] split = line.Trim(new char[] { '{', '}' }).Split(',');
                int xVal = int.Parse(split[0][(split[0].IndexOf('=') + 1)..]);
                int mVal = int.Parse(split[1][(split[1].IndexOf('=') + 1)..]);
                int aVal = int.Parse(split[2][(split[2].IndexOf('=') + 1)..]);
                int sVal = int.Parse(split[3][(split[3].IndexOf('=') + 1)..]);
                MachinePart machinePart = new(xVal, mVal, aVal, sVal);
                machineParts.Add(machinePart);
            }
        }

        int sum = 0;

        foreach (MachinePart machinePart in machineParts)
        {
            Workflow currentWorkflow = workflows["in"];
            string result = currentWorkflow.CheckMachinePart(machinePart);

            while (result != "R" && result != "A")
            {
                currentWorkflow = workflows[result];
                result = currentWorkflow.CheckMachinePart(machinePart);
            }

            if (result == "A")
            {
                sum += machinePart.TotalVal;
            }
        }

        Console.WriteLine("Part One : " + sum);
    }

    private static void PartTwo(string[] lines)
    {
        Dictionary<string, Workflow> workflows = new();

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                break;
            }

            string workflowName = line[..line.IndexOf('{')];
            string rules = line[(line.IndexOf('{') + 1)..line.IndexOf('}')];
            Workflow workflow = new(workflowName, rules);
            workflows.Add(workflowName, workflow);
        }

        int sum = 0;

        for (int x = 1; x <= 4000; x++)
        {
            for (int m = 1; m <= 4000; m++)
            {
                for (int a = 1; a <= 4000; a++)
                {
                    for (int s = 1; s <= 4000; s++)
                    {
                        MachinePart machinePart = new(x, m, a, s);
                        Workflow currentWorkflow = workflows["in"];
                        string result = currentWorkflow.CheckMachinePart(machinePart);

                        while (result != "R" && result != "A")
                        {
                            currentWorkflow = workflows[result];
                            result = currentWorkflow.CheckMachinePart(machinePart);
                        }

                        if (result == "A")
                        {
                            sum++;
                        }
                    }
                }
            }
        }

        Console.WriteLine("Part Two : " + sum);
    }
}
