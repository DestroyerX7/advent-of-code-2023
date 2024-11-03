namespace Day_18;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 18/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        return;

        GroundTile currentGroundTile = new(0, 0);

        foreach (string line in lines)
        {
            string[] split = line.Split(' ');

            char digDirection = split[0][0];
            int numDigTimes = int.Parse(split[1]);
            currentGroundTile = currentGroundTile.DigInDirection(digDirection, numDigTimes);
        }

        long minX = GroundTile.MinXPos();
        long maxX = GroundTile.MaxXPos();
        long minY = GroundTile.MinYPos();
        long maxY = GroundTile.MaxYPos();

        long num = GroundTile.GroundTiles.Count;

        for (long y = maxY; y >= minY; y--)
        {
            bool insideShape = false;

            for (long x = minX; x <= maxX; x++)
            {
                Position pos = new(x, y);

                if (GroundTile.PositionToGroundTile.ContainsKey(pos) && GroundTile.PositionToGroundTile[pos].HasWestFaceingWall())
                {
                    insideShape = !insideShape;
                }
                else if (insideShape && !GroundTile.PositionToGroundTile.ContainsKey(pos))
                {
                    num++;
                }
            }
        }

        Console.WriteLine("Part One : " + num);
    }

    private static void PartTwo(string[] lines)
    {
        GroundTile currentGroundTile = new(0, 0);

        Dictionary<char, char> digitToDirection = new()
        {
            { '0', 'R' },
            { '1', 'D' },
            { '2', 'L' },
            { '3', 'U' },
        };

        long num = 0;

        foreach (string line in lines)
        {
            string[] split = line.Split(' ');

            string color = split[2].Trim(new char[] { '(', ')', '#' });
            // long numDigTimes = HexadecimalColorToNum(color[..(color.Length - 1)]);
            // char digDirection = digitToDirection[color.Last()];
            currentGroundTile = currentGroundTile.DigInDirection(split[0][0], int.Parse(split[1]));
            num += int.Parse(split[1]);
        }

        long minX = GroundTile.MinXPos();
        long maxX = GroundTile.MaxXPos();
        long minY = GroundTile.MinYPos();
        long maxY = GroundTile.MaxYPos();

        for (long y = maxY; y >= minY; y--)
        {
            List<GroundTile> groundTilesOnY = GroundTile.GroundTiles.Where(g => g.YPos == y).OrderBy(g => g.XPos).ToList();
            bool insideShape = false;

            for (int i = 0; i < groundTilesOnY.Count; i++)
            {
                GroundTile groundTile = groundTilesOnY[i];
                if (groundTile.HasWestFaceingWall())
                {
                    insideShape = !insideShape;
                }
                else if (insideShape)
                {
                    num += groundTile.XPos - groundTilesOnY[i - 1].XPos;
                }
            }
        }

        Console.WriteLine("Part Two : " + num);
    }

    private static long HexadecimalColorToNum(string hexadecimalColor)
    {
        Dictionary<char, int> _hexadecimalLetterToNum = new()
        {
            { 'a', 10 },
            { 'b', 11 },
            { 'c', 12 },
            { 'd', 13 },
            { 'e', 14 },
            { 'f', 15 },
        };

        long hexadecimalNum = 0;
        int currentPower = 0;

        foreach (char character in hexadecimalColor.Reverse())
        {
            if (!int.TryParse(character.ToString(), out int num))
            {
                num = _hexadecimalLetterToNum[character];
            }

            hexadecimalNum += (long)(num * Math.Pow(16, currentPower));
            currentPower++;
        }

        return hexadecimalNum;
    }
}
