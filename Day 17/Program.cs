namespace Day_17;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 17/input.txt");

        int width = lines[0].Length;
        int height = lines.Length;

        CityBlock[,] cityBlocks = new CityBlock[lines[0].Length, lines.Length];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int heatLossAmount = int.Parse(lines[y][x].ToString());
                CityBlock cityBlock = new(heatLossAmount);
                cityBlocks[x, y] = cityBlock;
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                CityBlock cityBlock = cityBlocks[x, y];

                if (y != 0)
                {
                    cityBlock.AddConnection(cityBlocks[x, y - 1], Direction.Top);
                }

                if (y != height - 1)
                {
                    cityBlock.AddConnection(cityBlocks[x, y + 1], Direction.Bottom);
                }

                if (x != 0)
                {
                    cityBlock.AddConnection(cityBlocks[x - 1, y], Direction.Left);
                }

                if (x != width - 1)
                {
                    cityBlock.AddConnection(cityBlocks[x + 1, y], Direction.Right);
                }
            }
        }

        PartOne(cityBlocks);
        PartTwo(cityBlocks);
    }

    private static void PartOne(CityBlock[,] cityBlocks)
    {
        Console.WriteLine("Part One : ");
    }

    private static void PartTwo(CityBlock[,] cityBlocks)
    {
        Console.WriteLine("Part Two : ");
    }
}
