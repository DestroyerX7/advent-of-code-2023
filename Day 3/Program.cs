namespace Day_3;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/Advent of Code 2023/Day 3/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        int width = lines[0].Length;
        int height = lines.Length;
        char[,] graph = new char[width, height];

        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[0].Length; x++)
            {
                graph[x, y] = lines[y][x];
            }
        }

        int sum = 0;

        for (int y = 0; y < graph.GetLength(1); y++)
        {
            int lastDigitIndex = 0;
            bool consecutive = false;

            for (int x = 0; x < graph.GetLength(0); x++)
            {
                char element = graph[x, y];

                if (char.IsDigit(element) && !consecutive)
                {
                    lastDigitIndex = x;
                    consecutive = true;
                }

                if (!char.IsDigit(element) && consecutive)
                {
                    consecutive = false;

                    if (CheckAround(graph, y, lastDigitIndex, x - 1))
                    {
                        string numString = lines[y].Substring(lastDigitIndex, x - lastDigitIndex);
                        int num = int.Parse(numString);
                        sum += num;
                    }
                }
            }

            // Check again at the end incase the is a number at the end of the line
            if (char.IsDigit(graph[graph.GetLength(0) - 1, y]) && consecutive)
            {
                if (CheckAround(graph, y, lastDigitIndex, graph.GetLength(0) - 1))
                {
                    string numString = lines[y].Substring(lastDigitIndex, graph.GetLength(0) - lastDigitIndex);
                    int num = int.Parse(numString);
                    sum += num;
                }
            }
        }

        Console.WriteLine("Part One : " + sum);
    }

    private static bool CheckAround(char[,] graph, int height, int startIndex, int endIndex)
    {
        // Checking above number
        if (height != 0)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                char element = graph[i, height - 1];

                if (!char.IsDigit(element) && element != '.')
                {
                    return true;
                }
            }

            // Top left
            if (startIndex != 0)
            {
                char element = graph[startIndex - 1, height - 1];

                if (!char.IsDigit(element) && element != '.')
                {
                    return true;
                }
            }

            // Top right
            if (endIndex != graph.GetLength(0) - 1)
            {
                char element = graph[endIndex + 1, height - 1];

                if (!char.IsDigit(element) && element != '.')
                {
                    return true;
                }
            }
        }

        // Checking below number
        if (height != graph.GetLength(1) - 1)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                char element = graph[i, height + 1];

                if (!char.IsDigit(element) && element != '.')
                {
                    return true;
                }
            }

            // Bottom left
            if (startIndex != 0)
            {
                char element = graph[startIndex - 1, height + 1];

                if (!char.IsDigit(element) && element != '.')
                {
                    return true;
                }
            }

            // Bottom right
            if (endIndex != graph.GetLength(0) - 1)
            {
                char element = graph[endIndex + 1, height + 1];

                if (!char.IsDigit(element) && element != '.')
                {
                    return true;
                }
            }
        }

        // Checking to the left of number
        if (startIndex != 0)
        {
            char element = graph[startIndex - 1, height];

            if (!char.IsDigit(element) && element != '.')
            {
                return true;
            }
        }

        // Checking to the right of number
        if (endIndex != graph.GetLength(0) - 1)
        {
            char element = graph[endIndex + 1, height];

            if (!char.IsDigit(element) && element != '.')
            {
                return true;
            }
        }

        return false;
    }

    private static void PartTwo(string[] lines)
    {
        int width = lines[0].Length;
        int height = lines.Length;
        char[,] graph = new char[width, height];

        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[0].Length; x++)
            {
                graph[x, y] = lines[y][x];
            }
        }

        int sum = 0;

        for (int y = 0; y < graph.GetLength(1); y++)
        {
            for (int x = 0; x < graph.GetLength(0); x++)
            {
                char element = graph[x, y];

                if (element == '*')
                {
                    List<int[]> numPositions = CheckAroundGear(graph, x, y);

                    if (numPositions.Count == 2)
                    {
                        List<int> nums = GetNumsFromPositions(graph, numPositions);
                        sum += nums[0] * nums[1];
                    }
                }
            }
        }

        Console.WriteLine("Part Two : " + sum);
    }

    private static List<int[]> CheckAroundGear(char[,] graph, int xIndex, int height)
    {
        List<int[]> positions = new();

        // Checking above number
        if (height != 0)
        {
            char element = graph[xIndex, height - 1];

            if (char.IsDigit(element))
            {
                positions.Add(new int[] { xIndex, height - 1 });
            }

            // Top left
            if (xIndex != 0)
            {
                char element2 = graph[xIndex - 1, height - 1];

                if (char.IsDigit(element2) && !char.IsDigit(element))
                {
                    positions.Add(new int[] { xIndex - 1, height - 1 });
                }
            }

            // Top right
            if (xIndex != graph.GetLength(0) - 1)
            {
                char element3 = graph[xIndex + 1, height - 1];

                if (char.IsDigit(element3) && !char.IsDigit(element))
                {
                    positions.Add(new int[] { xIndex + 1, height - 1 });
                }
            }
        }

        // Checking below number
        if (height != graph.GetLength(1) - 1)
        {
            char element = graph[xIndex, height + 1];

            if (char.IsDigit(element))
            {
                positions.Add(new int[] { xIndex, height + 1 });
            }

            // Bottom left
            if (xIndex != 0)
            {
                char element2 = graph[xIndex - 1, height + 1];

                if (char.IsDigit(element2) && !char.IsDigit(element))
                {
                    positions.Add(new int[] { xIndex - 1, height + 1 });
                }
            }

            // Bottom right
            if (xIndex != graph.GetLength(0) - 1)
            {
                char element3 = graph[xIndex + 1, height + 1];

                if (char.IsDigit(element3) && !char.IsDigit(element))
                {
                    positions.Add(new int[] { xIndex + 1, height + 1 });
                }
            }
        }

        // Checking to the left of number
        if (xIndex != 0)
        {
            char element = graph[xIndex - 1, height];

            if (char.IsDigit(element))
            {
                positions.Add(new int[] { xIndex - 1, height });
            }
        }

        // Checking to the right of number
        if (xIndex != graph.GetLength(0) - 1)
        {
            char element = graph[xIndex + 1, height];

            if (char.IsDigit(element))
            {
                positions.Add(new int[] { xIndex + 1, height });
            }
        }

        return positions;
    }

    private static List<int> GetNumsFromPositions(char[,] graph, List<int[]> positions)
    {
        List<int> numsFound = new();

        foreach (int[] pos in positions)
        {
            int startIndex = pos[0];
            int endIndex = pos[0];
            int height = pos[1];

            while (startIndex > 0)
            {
                if (char.IsDigit(graph[startIndex - 1, height]))
                {
                    startIndex--;
                }
                else
                {
                    break;
                }
            }

            while (endIndex < graph.GetLength(0) - 1)
            {
                if (char.IsDigit(graph[endIndex + 1, height]))
                {
                    endIndex++;
                }
                else
                {
                    break;
                }
            }

            string numString = "";

            for (int i = 0; i <= endIndex - startIndex; i++)
            {
                numString += graph[startIndex + i, height];
            }

            int num = int.Parse(numString);
            numsFound.Add(num);
        }

        return numsFound;
    }
}
