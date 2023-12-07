using System.Globalization;

namespace Day_4;

public class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("D:/VS Code Projects/Advent of Code 2023/Day 4/input.txt");
        PartOne(lines);
        PartTwo(lines);
    }

    private static void PartOne(string[] lines)
    {
        int sum = 0;

        foreach (string line in lines)
        {
            string cardNumberString = line[(line.IndexOf(' ') + 1)..line.IndexOf(':')];
            int CardNum = int.Parse(cardNumberString);
            string winningNumbers = line[(line.IndexOf(':') + 2)..(line.IndexOf('|') - 1)];
            string playerNumbers = line[(line.IndexOf('|') + 2)..];
            Card card = new(CardNum, winningNumbers, playerNumbers);
            sum += card.GetValue();
        }

        Console.WriteLine("Part One : " + sum);
    }

    private static void PartTwo(string[] lines)
    {
        List<Card> cards = new();
        foreach (string line in lines)
        {
            string cardNumberString = line[(line.IndexOf(' ') + 1)..line.IndexOf(':')];
            int CardNum = int.Parse(cardNumberString);
            string winningNumbers = line[(line.IndexOf(':') + 2)..(line.IndexOf('|') - 1)];
            string playerNumbers = line[(line.IndexOf('|') + 2)..];
            Card card = new(CardNum, winningNumbers, playerNumbers);
            cards.Add(card);
        }

        int numOriginalCards = cards.Count;

        for (int i = 1; i <= numOriginalCards; i++)
        {
            Card[] cardsOfNum = cards.Where(c => c.Number == i).ToArray();
            int numWins = cardsOfNum.First().GetNumWins();

            for (int j = i + 1; j <= i + numWins; j++)
            {
                for (int k = 0; k < cardsOfNum.Length; k++)
                {
                    Card card = cards[j - 1].Clone();
                    cards.Add(card);
                }
            }
        }

        Console.WriteLine("Part Two : " + cards.Count);
    }
}
