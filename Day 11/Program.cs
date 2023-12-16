namespace Day_11;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 11/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        List<string> partiallyExpanded = new();

        foreach (string row in lines)
        {
            partiallyExpanded.Add(row);

            if (!row.Contains('#'))
            {
                partiallyExpanded.Add(row);
            }
        }

        List<string> expandedUniverse = new();

        foreach (string row in partiallyExpanded)
        {
            string newLine = "";

            for (int i = 0; i < row.Length; i++)
            {
                bool noGalaxies = true;

                for (int j = 0; j < partiallyExpanded.Count; j++)
                {
                    if (partiallyExpanded[j][i] == '#')
                    {
                        noGalaxies = false;
                    }
                }

                newLine += row[i];

                if (noGalaxies)
                {
                    newLine += row[i];
                }
            }

            expandedUniverse.Add(newLine);
        }

        UniverseNode[,] universeNodes = new UniverseNode[expandedUniverse[0].Length, expandedUniverse.Count];
        List<UniverseNode> galaxyNodes = new();

        int width = universeNodes.GetLength(0);
        int height = universeNodes.GetLength(1);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                UniverseNode universeNode = new(x, y);
                universeNodes[x, y] = universeNode;

                if (expandedUniverse[y][x] == '#')
                {
                    galaxyNodes.Add(universeNode);
                }
            }
        }

        long sumAllShortestPaths = 0;

        for (int i = 0; i < galaxyNodes.Count; i++)
        {
            UniverseNode galaxy = galaxyNodes[i];

            for (int j = i + 1; j < galaxyNodes.Count; j++)
            {
                UniverseNode target = galaxyNodes[j];
                sumAllShortestPaths += galaxy.GetShortestPath(target);
            }
        }

        Console.WriteLine("Part One : " + sumAllShortestPaths);
    }

    private static void PartTwo(string[] lines)
    {
        List<long> rowsWithNoGalaxies = new();

        for (int i = 0; i < lines.Length; i++)
        {
            if (!lines[i].Contains('#'))
            {
                rowsWithNoGalaxies.Add(i);
            }
        }

        List<long> columnsWithNoGamaxies = new();

        for (int i = 0; i < lines[0].Length; i++)
        {
            bool noGalaxies = true;

            for (int j = 0; j < lines.Length; j++)
            {
                if (lines[j][i] == '#')
                {
                    noGalaxies = false;
                }
            }

            if (noGalaxies)
            {
                columnsWithNoGamaxies.Add(i);
            }
        }

        UniverseNode[,] universeNodes = new UniverseNode[lines[0].Length, lines.Length];
        List<UniverseNode> galaxyNodes = new();

        int width = universeNodes.GetLength(0);
        int height = universeNodes.GetLength(1);

        long yPos = 0;

        for (int y = 0; y < height; y++)
        {
            if (rowsWithNoGalaxies.Contains(y))
            {
                yPos += 1000000 - 1;
            }

            long xPos = 0;

            for (int x = 0; x < width; x++)
            {
                if (columnsWithNoGamaxies.Contains(x))
                {
                    xPos += 1000000 - 1;
                }

                UniverseNode universeNode = new(xPos, yPos);
                universeNodes[x, y] = universeNode;

                if (lines[y][x] == '#')
                {
                    galaxyNodes.Add(universeNode);
                }

                xPos++;
            }

            yPos++;
        }

        long sumAllShortestPaths = 0;

        for (int i = 0; i < galaxyNodes.Count; i++)
        {
            UniverseNode galaxy = galaxyNodes[i];

            for (int j = i + 1; j < galaxyNodes.Count; j++)
            {
                UniverseNode target = galaxyNodes[j];
                sumAllShortestPaths += galaxy.GetShortestPath(target);
            }
        }

        Console.WriteLine("Part Two : " + sumAllShortestPaths);
    }
}
