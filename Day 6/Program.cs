namespace Day_6;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 6/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        int[] times = lines[0][(lines[0].IndexOf(":") + 1)..].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] distances = lines[1][(lines[1].IndexOf(":") + 1)..].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int multiplied = 1;

        for (int i = 0; i < times.Length; i++)
        {
            int numWinningTimes = 0;

            for (int j = 0; j < times[i]; j++)
            {
                int recordDistance = distances[i];
                int calculatedDistance = j * (times[i] - j);

                if (calculatedDistance > recordDistance)
                {
                    numWinningTimes++;
                }
            }

            multiplied *= numWinningTimes;
        }

        Console.WriteLine("Part One : " + multiplied);
    }

    private static void PartTwo(string[] lines)
    {
        char[] timeNums = lines[0][(lines[0].IndexOf(":") + 1)..].Where(char.IsDigit).ToArray();
        int time = int.Parse(string.Concat(timeNums));

        char[] distanceNums = lines[1][(lines[1].IndexOf(":") + 1)..].Where(char.IsDigit).ToArray();
        long recordDistance = long.Parse(string.Concat(distanceNums));

        long numWinningTimes = 0;

        for (long i = 0; i < time; i++)
        {
            long calculatedDistance = i * (time - i);

            if (calculatedDistance > recordDistance)
            {
                numWinningTimes++;
            }
        }

        Console.WriteLine("Part Two : " + numWinningTimes);
    }
}
