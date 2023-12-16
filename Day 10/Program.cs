namespace Day_10;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 10/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        Tile[,] tiles = new Tile[lines[0].Length, lines.Length];
        Tile? startTile = null;

        for (int x = 0; x < lines[0].Length; x++)
        {
            for (int y = 0; y < lines.Length; y++)
            {
                char tileType = lines[y][x];
                Tile tile = new(tileType);
                tiles[x, y] = tile;

                if (tileType == 'S')
                {
                    startTile = tile;
                }
            }
        }

        int width = tiles.GetLength(0);
        int height = tiles.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Tile tile = tiles[x, y];

                // Setting up
                if (y != 0)
                {
                    tile.Up = tiles[x, y - 1];
                }

                // Setting Down
                if (y != height - 1)
                {
                    tile.Down = tiles[x, y + 1];
                }

                // Setting Left
                if (x != 0)
                {
                    tile.Left = tiles[x - 1, y];
                }

                // Setting right
                if (x != width - 1)
                {
                    tile.Right = tiles[x + 1, y];
                }
            }
        }

        foreach (Tile tile in tiles)
        {
            tile.SetConnections();
        }

        int loopDistance = 0;
        Tile? previous = null;
        Tile? currentTile = startTile;
        Tile? nextTile = currentTile?.NextInLoop(previous);

        while (currentTile != null && nextTile != null && nextTile.TileType != 'S')
        {
            Tile temp = currentTile;
            currentTile = currentTile.NextInLoop(previous);
            previous = temp;
            nextTile = currentTile?.NextInLoop(previous);
            loopDistance++;
        }

        int furthestDistance = (int)Math.Ceiling((double)loopDistance / 2);

        Console.WriteLine("Part One : " + furthestDistance);
    }

    private static void PartTwo(string[] lines)
    {
        Tile[,] tiles = new Tile[lines[0].Length, lines.Length];
        Tile? startTile = null;

        for (int x = 0; x < lines[0].Length; x++)
        {
            for (int y = 0; y < lines.Length; y++)
            {
                char tileType = lines[y][x];
                Tile tile = new(tileType);
                tiles[x, y] = tile;

                if (tileType == 'S')
                {
                    startTile = tile;
                }
            }
        }

        int width = tiles.GetLength(0);
        int height = tiles.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Tile tile = tiles[x, y];

                // Setting up
                if (y != 0)
                {
                    tile.Up = tiles[x, y - 1];
                }

                // Setting Down
                if (y != height - 1)
                {
                    tile.Down = tiles[x, y + 1];
                }

                // Setting Left
                if (x != 0)
                {
                    tile.Left = tiles[x - 1, y];
                }

                // Setting right
                if (x != width - 1)
                {
                    tile.Right = tiles[x + 1, y];
                }
            }
        }

        foreach (Tile tile in tiles)
        {
            tile.SetConnections();
        }

        Tile? previous = null;
        Tile? currentTile = startTile;
        Tile? nextTile = currentTile?.NextInLoop(previous);

        while (currentTile != null && nextTile != null && nextTile.TileType != 'S')
        {
            currentTile.LoopTile = true;
            Tile temp = currentTile;
            currentTile = currentTile.NextInLoop(previous);
            previous = temp;
            nextTile = currentTile?.NextInLoop(previous);
        }

        // Setting the last loop tile as a loop tile
        if (currentTile != null)
        {
            currentTile.LoopTile = true;
        }

        // Converts the TileType of the start tile from S to what it should be
        startTile?.ConvertStartTile();

        int numInside = 0;

        for (int y = 0; y < height; y++)
        {
            bool isInside = false;

            for (int x = 0; x < width; x++)
            {
                Tile tile = tiles[x, y];

                if (tile.LoopTile)
                {
                    if (tile.HasNorthFacingSide())
                    {
                        isInside = !isInside;
                    }
                }
                else if (isInside)
                {
                    numInside++;
                }
            }
        }

        Console.WriteLine("Part Two : " + numInside);
    }
}
