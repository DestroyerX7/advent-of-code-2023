namespace Day_7;

public class Card : IComparable<Card>
{
    public char Face { get; private set; }

    private static readonly Dictionary<char, int> _faceToValueMap = new()
    {
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 'T', 10 },
        { 'Q', 12 },
        { 'K', 13 },
        { 'A', 14 },
    };

    public Card(char face, bool partOne)
    {
        Face = face;

        if (_faceToValueMap.ContainsKey('J') && partOne && _faceToValueMap['J'] == 11)
        {
            return;
        }
        else if (_faceToValueMap.ContainsKey('J') && !partOne && _faceToValueMap['J'] == 1)
        {
            return;
        }

        _faceToValueMap.Remove('J');

        if (partOne)
        {
            _faceToValueMap.Add('J', 11);
        }
        else
        {
            _faceToValueMap.Add('J', 1);
        }
    }

    public int CompareTo(Card? other)
    {
        if (other == null)
        {
            return 1;
        }

        return _faceToValueMap[Face] - _faceToValueMap[other.Face];
    }
}