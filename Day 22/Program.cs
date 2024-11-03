namespace Day_22;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 22/input.txt");
        PartOne(lines);
        // PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        foreach (string line in lines)
        {
            string[] ends = line.Split('~');
            int[] endOneNums = ends[0].Split(',').Select(int.Parse).ToArray();
            int[] endTwoNums = ends[1].Split(',').Select(int.Parse).ToArray();
            Position positionOne = new(endOneNums[0], endOneNums[1], endOneNums[2]);
            Position positionTwo = new(endTwoNums[0], endTwoNums[1], endTwoNums[2]);

            Brick brick = new(positionOne, positionTwo);
        }

        Console.WriteLine("Part One : ");
    }

    private static void PartTwo(string[] lines)
    {
        Console.WriteLine("Part Two : ");
    }
}
