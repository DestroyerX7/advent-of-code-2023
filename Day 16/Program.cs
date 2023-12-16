namespace Day_16;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 16/input.txt");

        int width = lines[0].Length;
        int height = lines.Length;

        GridTile[,] tileGrid = new GridTile[lines[0].Length, lines.Length];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char tileType = lines[y][x];
                tileGrid[x, y] = new GridTile(tileType, null, null, null, null);
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GridTile tile = tileGrid[x, y];

                if (y != 0)
                {
                    tile.TopTile = tileGrid[x, y - 1];
                }

                if (y != height - 1)
                {
                    tile.BottomTile = tileGrid[x, y + 1];
                }

                if (x != 0)
                {
                    tile.LeftTile = tileGrid[x - 1, y];
                }

                if (x != width - 1)
                {
                    tile.RightTile = tileGrid[x + 1, y];
                }
            }
        }

        PartOne(tileGrid);
        PartTwo(tileGrid);
    }

    private static void PartOne(GridTile[,] tileGrid)
    {
        tileGrid[0, 0].EnterFromLeft();

        int numEnergized = 0;

        foreach (GridTile gridTile in tileGrid)
        {
            if (gridTile.Energized)
            {
                numEnergized++;
            }
        }

        Console.WriteLine("Part One : " + numEnergized);
    }

    private static void PartTwo(GridTile[,] tileGrid)
    {
        foreach (GridTile gridTile in tileGrid)
        {
            gridTile.Rest();
        }

        int width = tileGrid.GetLength(0);
        int height = tileGrid.GetLength(1);

        int greatestNumEnergized = 0;

        for (int x = 0; x < width; x++)
        {
            tileGrid[x, 0].EnterFromTop();

            int numEnergized = 0;

            foreach (GridTile gridTile in tileGrid)
            {
                if (gridTile.Energized)
                {
                    numEnergized++;
                }

                gridTile.Rest();
            }

            if (numEnergized > greatestNumEnergized)
            {
                greatestNumEnergized = numEnergized;
            }

            tileGrid[x, height - 1].EnterFromBottom();

            numEnergized = 0;

            foreach (GridTile gridTile in tileGrid)
            {
                if (gridTile.Energized)
                {
                    numEnergized++;
                }

                gridTile.Rest();
            }

            if (numEnergized > greatestNumEnergized)
            {
                greatestNumEnergized = numEnergized;
            }
        }

        for (int y = 0; y < height; y++)
        {
            tileGrid[0, y].EnterFromLeft();

            int numEnergized = 0;

            foreach (GridTile gridTile in tileGrid)
            {
                if (gridTile.Energized)
                {
                    numEnergized++;
                }

                gridTile.Rest();
            }

            if (numEnergized > greatestNumEnergized)
            {
                greatestNumEnergized = numEnergized;
            }

            tileGrid[width - 1, y].EnterFromRight();

            numEnergized = 0;

            foreach (GridTile gridTile in tileGrid)
            {
                if (gridTile.Energized)
                {
                    numEnergized++;
                }

                gridTile.Rest();
            }

            if (numEnergized > greatestNumEnergized)
            {
                greatestNumEnergized = numEnergized;
            }
        }

        Console.WriteLine("Part Two : " + greatestNumEnergized);
    }
}
