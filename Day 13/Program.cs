namespace Day_13;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 13/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        int sumNumLeftOfReflection = 0;
        int sumNumAboveReflection = 0;

        List<string> patterns = new();

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                Pattern pattern = new(patterns);
                sumNumLeftOfReflection += pattern.GetNumLeftOfReflection();
                sumNumAboveReflection += pattern.GetNumAboveReflection();
                patterns.Clear();
                continue;
            }

            patterns.Add(line);
        }

        Pattern lastPattern = new(patterns);
        sumNumLeftOfReflection += lastPattern.GetNumLeftOfReflection();
        sumNumAboveReflection += lastPattern.GetNumAboveReflection();
        patterns.Clear();

        Console.WriteLine("Part One : " + (sumNumLeftOfReflection + 100 * sumNumAboveReflection));
    }

    private static void PartTwo(string[] lines)
    {
        int sumNumLeftOfReflection = 0;
        int sumNumAboveReflection = 0;

        List<string> patterns = new();

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                Pattern pattern = new(patterns);
                pattern.FixSmudge();

                sumNumAboveReflection += pattern.NumAboveAfterRemovingSmudge;
                sumNumLeftOfReflection += pattern.NumLeftAfterRemovingSmudge;

                patterns.Clear();
                continue;
            }

            patterns.Add(line);
        }

        Pattern lastPattern = new(patterns);
        lastPattern.FixSmudge();

        sumNumAboveReflection += lastPattern.NumAboveAfterRemovingSmudge;
        sumNumLeftOfReflection += lastPattern.NumLeftAfterRemovingSmudge;

        patterns.Clear();

        Console.WriteLine("Part Two : " + (sumNumLeftOfReflection + 100 * sumNumAboveReflection));
    }
}
