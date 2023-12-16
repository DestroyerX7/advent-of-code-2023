namespace Day_14;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 14/input.txt");

        Rock?[,] grid = new Rock[lines[0].Length, lines.Length];

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                char character = lines[y][x];

                if (character == '.')
                {
                    continue;
                }

                Rock rock = new(character, x, y);
                grid[x, y] = rock;
            }
        }

        PartOne(grid);
        PartTwo(grid);
    }

    private static void PartOne(Rock?[,] grid)
    {
        int width = grid.GetLength(0);
        int height = grid.GetLength(1);

        List<Rock> roundedRocks = new();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Rock? rock = grid[x, y];

                if (rock == null || rock.RockType == '#')
                {
                    continue;
                }

                roundedRocks.Add(rock);

                while (rock.YPos > 0 && grid[x, rock.YPos - 1] == null)
                {
                    grid[x, rock.YPos - 1] = rock;
                    grid[x, rock.YPos] = null;
                    rock.RollNorth();
                }
            }
        }

        int sumLoad = 0;

        foreach (Rock rock in roundedRocks)
        {
            sumLoad += height - rock.YPos;
        }

        Console.WriteLine("Part One : " + sumLoad);
    }

    private static void PartTwo(Rock?[,] grid)
    {
        int width = grid.GetLength(0);
        int height = grid.GetLength(1);

        List<Rock> roundedRocks = new();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Rock? rock = grid[x, y];

                if (rock == null || rock.RockType == '#')
                {
                    continue;
                }

                roundedRocks.Add(rock);
            }
        }

        for (int i = 0; i < 1000000000; i++)
        {
            // North
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Rock? rock = grid[x, y];

                    if (rock == null || rock.RockType == '#')
                    {
                        continue;
                    }

                    while (rock.YPos > 0 && grid[x, rock.YPos - 1] == null)
                    {
                        grid[x, rock.YPos - 1] = rock;
                        grid[x, rock.YPos] = null;
                        rock.RollNorth();
                    }
                }
            }

            // West
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Rock? rock = grid[x, y];

                    if (rock == null || rock.RockType == '#')
                    {
                        continue;
                    }

                    while (rock.XPos > 0 && grid[rock.XPos - 1, y] == null)
                    {
                        grid[rock.XPos - 1, y] = rock;
                        grid[rock.XPos, y] = null;
                        rock.RollWest();
                    }
                }
            }
        }

        int sumLoad = 0;

        foreach (Rock rock in roundedRocks)
        {
            sumLoad += height - rock.YPos;
        }

        Console.WriteLine("Part Two : " + sumLoad);
    }
}
