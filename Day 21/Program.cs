namespace Day_21;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 21/input.txt");

        int width = lines[0].Length;
        int height = lines.Length;

        GardenPlot[,] gardenPlots = new GardenPlot[width, height];
        GardenPlot start = null;

        // Creating garden plots
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char character = lines[y][x];

                if (character == '#')
                {
                    continue;
                }

                GardenPlot gardenPlot = new(x, y);
                gardenPlots[x, y] = gardenPlot;

                if (character == 'S')
                {
                    start = gardenPlot;
                }
            }
        }

        // Setting up connections
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (gardenPlots[x, y] == null)
                {
                    continue;
                }

                GardenPlot gardenPlot = gardenPlots[x, y];

                if (y != 0 && gardenPlots[x, y - 1] != null)
                {
                    gardenPlot.AddConnection(gardenPlots[x, y - 1]);
                }

                if (y != height - 1 && gardenPlots[x, y + 1] != null)
                {
                    gardenPlot.AddConnection(gardenPlots[x, y + 1]);
                }

                if (x != 0 && gardenPlots[x - 1, y] != null)
                {
                    gardenPlot.AddConnection(gardenPlots[x - 1, y]);
                }

                if (x != width - 1 && gardenPlots[x + 1, y] != null)
                {
                    gardenPlot.AddConnection(gardenPlots[x + 1, y]);
                }
            }
        }

        PartOne(gardenPlots, start);
    }

    private static void PartOne(GardenPlot[,] gardenPlots, GardenPlot start)
    {
        start.GetNum();

        int num = 0;

        foreach (GardenPlot gardenPlot in gardenPlots)
        {
            if (gardenPlot != null && gardenPlot.CanBeReached)
            {
                num++;
            }
        }

        Console.WriteLine("Part One : " + num);
    }

    private static void PartTwo(string[] lines)
    {
        Console.WriteLine("Part Two : ");
    }
}
