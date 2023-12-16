namespace Day_12;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 12/input.txt");
        PartOne(lines);
    }

    private static void PartOne(string[] lines)
    {
        int sum = 0;

        foreach (string line in lines)
        {
            ConditionRecord conditionRecord = new(line);
            sum += conditionRecord.GetNumPossabilities();
        }

        Console.WriteLine("Part One : " + sum);
    }

    private static void PartTwo(string[] lines)
    {
        Console.WriteLine("Part Two : ");
    }
}
