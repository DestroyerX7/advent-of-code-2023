namespace Day_8;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 8/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        Dictionary<string, Node> posToNode = new();

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line) || !line.Contains('='))
            {
                continue;
            }

            string[] split = line.Split(new char[] { '=', ',' }).Select(s => s.Trim(new char[] { ' ', '(', ')' })).ToArray();

            Node node = new(split[0], split[1], split[2]);
            posToNode.Add(split[0], node);
        }

        Node currentNode = posToNode["AAA"];
        int directionIndex = 0;
        long numDirections = 1;
        char currentDirection = lines[0][directionIndex];

        while (currentNode.GetDirection(currentDirection) != "ZZZ")
        {
            string nextNode = currentNode.GetDirection(currentDirection);
            currentNode = posToNode[nextNode];
            directionIndex = ++directionIndex % lines[0].Length;
            currentDirection = lines[0][directionIndex];
            numDirections++;
        }

        Console.WriteLine("Part One : " + numDirections);
    }

    private static void PartTwo(string[] lines)
    {
        Dictionary<string, Node> posToNode = new();

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line) || !line.Contains('='))
            {
                continue;
            }

            string[] split = line.Split(new char[] { '=', ',' }).Select(s => s.Trim(new char[] { ' ', '(', ')' })).ToArray();

            Node node = new(split[0], split[1], split[2]);
            posToNode.Add(split[0], node);
        }

        List<Node> nodes = posToNode.Values.Where(n => n.Position.EndsWith("A")).ToList();

        List<long> nums = new();

        foreach (Node node in nodes)
        {
            long numDirections = 0;
            int directionIndex = 0;
            char currentDirection = lines[0][directionIndex];
            Node startNode = posToNode[node.GetDirection(currentDirection)];
            Node currentNode = node;

            while (!currentNode.Position.EndsWith("Z"))
            {
                string nextNodePos = currentNode.GetDirection(currentDirection);
                currentNode = posToNode[nextNodePos];
                directionIndex = ++directionIndex % lines[0].Length;
                currentDirection = lines[0][directionIndex];
                numDirections++;
            }

            nums.Add(numDirections);
        }

        long gcf = 1;

        for (long i = nums.Max(); i >= 0; i--)
        {
            bool allDivisable = true;

            foreach (long num in nums)
            {
                double divided = (double)num / i;

                if (divided % 1 != 0)
                {
                    allDivisable = false;
                    break;
                }
            }

            if (allDivisable)
            {
                gcf = i;
                break;
            }
        }

        long lcm = nums.Aggregate((long numOne, long numTwo) => numOne / gcf * numTwo);

        Console.WriteLine("Part Two : " + lcm);
    }
}
