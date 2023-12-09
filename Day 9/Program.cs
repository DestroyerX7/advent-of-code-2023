namespace Day_9;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 9/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        int sum = 0;

        foreach (string line in lines)
        {
            OasisReportLine oasisReportLine = new(line);
            sum += oasisReportLine.ExtrapolateRight();
        }

        Console.WriteLine("Part One : " + sum);
    }

    private static void PartTwo(string[] lines)
    {
        int sum = 0;

        foreach (string line in lines)
        {
            OasisReportLine oasisReportLine = new(line);
            sum += oasisReportLine.ExtrapolateLeft();
        }

        Console.WriteLine("Part Two : " + sum);
    }
}
