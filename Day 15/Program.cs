namespace Day_15;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/advent-of-code-2023/Day 15/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        int sum = 0;

        foreach (string line in lines)
        {
            string[] steps = line.Split(',');

            foreach (string step in steps)
            {
                int currentVal = 0;

                foreach (char character in step)
                {
                    int hashVal = character.GetHashCode();
                    currentVal += hashVal;
                    currentVal *= 17;
                    currentVal %= 256;
                }

                sum += currentVal;
            }
        }

        Console.WriteLine("Part One : " + sum);
    }

    private static void PartTwo(string[] lines)
    {
        Box[] boxes = new Box[256];

        for (int i = 0; i < boxes.Length; i++)
        {
            boxes[i] = new Box(i);
        }

        foreach (string line in lines)
        {
            string[] lenses = line.Split(',');

            foreach (string lens in lenses)
            {
                int currentVal = 0;
                string label = lens.Contains('=') ? lens[..lens.IndexOf('=')] : lens[..lens.IndexOf('-')];

                foreach (char character in label)
                {
                    int hashVal = character.GetHashCode();
                    currentVal += hashVal;
                    currentVal *= 17;
                    currentVal %= 256;
                }

                if (lens.Contains('='))
                {
                    int focalLength = int.Parse(lens[(lens.IndexOf('=') + 1)..]);
                    Lens lensToAdd = new(label, focalLength);
                    boxes[currentVal].AddLens(lensToAdd);
                }
                else
                {
                    boxes[currentVal].RemoveLens(label);
                }
            }
        }

        int sum = 0;

        foreach (Box box in boxes)
        {
            sum += box.GetSumFocusingPower();
        }

        Console.WriteLine("Part Two : " + sum);
    }
}
