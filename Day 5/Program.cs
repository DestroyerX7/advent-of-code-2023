namespace Day_5;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 5/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        List<ConversionRange> conversionRanges = new();
        List<Conversion> conversions = new();

        foreach (string line in lines)
        {
            if (line.EndsWith("map:"))
            {
                Conversion conversion = new(conversionRanges);
                conversions.Add(conversion);
                conversionRanges.Clear();
                continue;
            }

            if (line.StartsWith("seeds:") || string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] nums = line.Split(" ");
            long destinationStart = long.Parse(nums[0]);
            long sourceStart = long.Parse(nums[1]);
            long length = long.Parse(nums[2]);
            ConversionRange conversionRange = new(destinationStart, sourceStart, length);
            conversionRanges.Add(conversionRange);
        }

        Conversion lastConversion = new(conversionRanges);
        conversions.Add(lastConversion);
        conversionRanges.Clear();

        long lowest = long.MaxValue;

        string[] seeds = lines[0][(lines[0].IndexOf(" ") + 1)..].Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string seed in seeds)
        {
            long sourceNum = long.Parse(seed);

            foreach (Conversion conversion in conversions)
            {
                sourceNum = conversion.GetDestinationNum(sourceNum);
            }

            if (sourceNum < lowest)
            {
                lowest = sourceNum;
            }
        }

        Console.WriteLine("Part One : " + lowest);
    }

    private static void PartTwo(string[] lines)
    {
        List<ConversionRange> conversionRanges = new();
        List<Conversion> conversions = new();

        foreach (string line in lines)
        {
            if (line.EndsWith("map:"))
            {
                Conversion conversion = new(conversionRanges);
                conversions.Add(conversion);
                conversionRanges.Clear();
                continue;
            }

            if (line.StartsWith("seeds:") || string.IsNullOrEmpty(line))
            {
                continue;
            }

            string[] nums = line.Split(" ");
            long destinationStart = long.Parse(nums[0]);
            long sourceStart = long.Parse(nums[1]);
            long length = long.Parse(nums[2]);
            ConversionRange conversionRange = new(destinationStart, sourceStart, length);
            conversionRanges.Add(conversionRange);
        }

        Conversion lastConversion = new(conversionRanges);
        conversions.Add(lastConversion);
        conversionRanges.Clear();

        string[] seedsUnformatted = lines[0][(lines[0].IndexOf(" ") + 1)..].Split(" ", StringSplitOptions.RemoveEmptyEntries);

        for (long i = 0; i < long.MaxValue; i++)
        {
            long neededNum = Conversion.IsPossible(i, conversions, conversions.Count - 1);

            for (int j = 0; j < seedsUnformatted.Length; j += 2)
            {
                long startSeed = long.Parse(seedsUnformatted[j]);
                long length = long.Parse(seedsUnformatted[j + 1]);
                long endSeed = startSeed + length - 1;

                if (neededNum >= startSeed && neededNum <= endSeed)
                {
                    Console.WriteLine("Part Two : " + i);
                    return;
                }
            }
        }
    }
}
