namespace Day_4;

public class Card
{
    public int Number { get; }

    private readonly List<int> _winningNumbers = new();
    private readonly List<int> _playerNumbers = new();

    public Card(int number, string winnningNumbers, string playerNumbers)
    {
        Number = number;
        _winningNumbers = winnningNumbers.Split(new string[] { " ", "  " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        _playerNumbers = playerNumbers.Split(new string[] { " ", "  " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    }

    public Card(int number, List<int> winnningNumbers, List<int> playerNumbers)
    {
        Number = number;
        _winningNumbers = new(winnningNumbers);
        _playerNumbers = new(playerNumbers);
    }

    public int GetValue()
    {
        int numInterections = _winningNumbers.Intersect(_playerNumbers).Count();
        return numInterections > 0 ? (int)Math.Pow(2, numInterections - 1) : 0;
    }

    public int GetNumWins()
    {
        return _winningNumbers.Intersect(_playerNumbers).Count();
    }

    public Card Clone()
    {
        return new Card(Number, _winningNumbers, _playerNumbers);
    }
}
