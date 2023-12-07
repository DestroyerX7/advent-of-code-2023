namespace Day_7;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/Advent of Code 2023/Day 7/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        List<CamelCardsHand> hands = new();

        foreach (string line in lines)
        {
            string[] split = line.Split(" ");
            string hand = split[0];
            int betAmount = int.Parse(split[1]);
            CamelCardsHand camelCardsHand = new(hand, betAmount, true);
            hands.Add(camelCardsHand);
        }

        hands = hands.OrderBy(h => h).ToList();

        long sum = 0;

        for (int i = 0; i < hands.Count; i++)
        {
            CamelCardsHand hand = hands[i];
            sum += (i + 1) * hand.BetAmount;
        }

        Console.WriteLine("Part One : " + sum);
    }

    private static void PartTwo(string[] lines)
    {
        List<CamelCardsHand> hands = new();

        foreach (string line in lines)
        {
            string[] split = line.Split(" ");
            string hand = split[0];
            int betAmount = int.Parse(split[1]);
            CamelCardsHand camelCardsHand = new(hand, betAmount, false);
            hands.Add(camelCardsHand);
        }

        hands = hands.OrderBy(h => h).ToList();

        long sum = 0;

        for (int i = 0; i < hands.Count; i++)
        {
            CamelCardsHand hand = hands[i];
            sum += (i + 1) * hand.BetAmount;
        }

        Console.WriteLine("Part Two : " + sum);
    }
}
