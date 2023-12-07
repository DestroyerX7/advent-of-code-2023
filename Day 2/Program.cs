namespace Day_2;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/Advent of Code 2023/Day 2/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        Dictionary<string, int> maxColorPairs = new()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 },
        };

        int sumPossibleGames = 0;

        int currentGame = 1;

        foreach (string line in lines)
        {
            string formatted = line.Substring(line.IndexOf(':') + 1);
            string[] sets = formatted.Split(new char[] { ';', ',' });
            bool possibleGame = true;

            foreach (string set in sets)
            {
                string formattedNumColor = set.Trim();
                string numString = formattedNumColor.Substring(0, formattedNumColor.IndexOf(' '));
                string color = formattedNumColor.Substring(formattedNumColor.IndexOf(' ') + 1);

                int num = int.Parse(numString);

                if (num > maxColorPairs[color])
                {
                    possibleGame = false;
                    break;
                }
            }

            if (possibleGame)
            {
                sumPossibleGames += currentGame;
            }

            currentGame++;
        }

        Console.WriteLine("Part One : " + sumPossibleGames);
    }

    private static void PartTwo(string[] lines)
    {
        int sum = 0;

        foreach (string line in lines)
        {
            Dictionary<string, int> maxNumColors = new()
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 },
            };

            string formatted = line.Substring(line.IndexOf(':') + 1);
            string[] sets = formatted.Split(new char[] { ';', ',' });

            foreach (string set in sets)
            {
                string formattedNumColor = set.Trim();
                string numString = formattedNumColor.Substring(0, formattedNumColor.IndexOf(' '));
                string color = formattedNumColor.Substring(formattedNumColor.IndexOf(' ') + 1);

                int num = int.Parse(numString);

                if (num > maxNumColors[color])
                {
                    maxNumColors[color] = num;
                }
            }

            int multiplied = maxNumColors["red"] * maxNumColors["green"] * maxNumColors["blue"];
            sum += multiplied;
        }

        Console.WriteLine("Part Two : " + sum);
    }
}
