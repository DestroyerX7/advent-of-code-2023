namespace Day_7;

public enum HandType
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind
}

public class CamelCardsHand : IComparable<CamelCardsHand>
{
    private readonly List<Card> _cards = new();
    public int BetAmount { get; private set; }
    private HandType _handType;

    public CamelCardsHand(string hand, int betAmount, bool partOne)
    {
        foreach (char cardFace in hand)
        {
            Card card = new(cardFace, partOne);
            _cards.Add(card);
        }

        BetAmount = betAmount;
        _handType = partOne ? GetHandType() : GetHandTypeUsingJokers();
    }

    public HandType GetHandType()
    {
        List<char> chars = _cards.Select(c => c.Face).Distinct().ToList();
        chars = chars.OrderByDescending(c => _cards.Where(card => c == card.Face).Count()).ToList();
        int biggestNumOccurances = _cards.Where(card => chars[0] == card.Face).Count();

        int secondBiggestNumOccurances = 1;

        if (chars.Count > 1)
        {
            secondBiggestNumOccurances = _cards.Where(card => chars[1] == card.Face).Count();
        }

        if (biggestNumOccurances == 5)
        {
            return HandType.FiveOfAKind;
        }
        else if (biggestNumOccurances == 4)
        {
            return HandType.FourOfAKind;
        }
        else if (biggestNumOccurances == 3 && secondBiggestNumOccurances == 2)
        {
            return HandType.FullHouse;
        }
        else if (biggestNumOccurances == 3)
        {
            return HandType.ThreeOfAKind;
        }
        else if (biggestNumOccurances == 2 && secondBiggestNumOccurances == 2)
        {
            return HandType.TwoPair;
        }
        else if (biggestNumOccurances == 2)
        {
            return HandType.OnePair;
        }
        else
        {
            return HandType.HighCard;
        }
    }

    public HandType GetHandTypeUsingJokers()
    {
        List<char> chars = _cards.Select(c => c.Face).Distinct().ToList();
        chars = chars.OrderByDescending(c => _cards.Where(card => c == card.Face || card.Face == 'J').Count()).ToList();
        int biggestNumOccurances = _cards.Where(card => chars[0] == card.Face || card.Face == 'J').Count();

        int secondBiggestNumOccurances = 1;

        if (chars.Count > 1)
        {
            secondBiggestNumOccurances = _cards.Where(card => chars[1] == card.Face).Count();
        }

        if (biggestNumOccurances == 5)
        {
            return HandType.FiveOfAKind;
        }
        else if (biggestNumOccurances == 4)
        {
            return HandType.FourOfAKind;
        }
        else if (biggestNumOccurances == 3 && secondBiggestNumOccurances == 2)
        {
            return HandType.FullHouse;
        }
        else if (biggestNumOccurances == 3)
        {
            return HandType.ThreeOfAKind;
        }
        else if (biggestNumOccurances == 2 && secondBiggestNumOccurances == 2)
        {
            return HandType.TwoPair;
        }
        else if (biggestNumOccurances == 2)
        {
            return HandType.OnePair;
        }
        else
        {
            return HandType.HighCard;
        }
    }

    public int CompareTo(CamelCardsHand? other)
    {
        if (other == null)
        {
            return 1;
        }

        if (other._handType != _handType)
        {
            return _handType - other._handType;
        }

        for (int i = 0; i < _cards.Count; i++)
        {
            int compared = _cards[i].CompareTo(other._cards[i]);

            if (compared != 0)
            {
                return compared;
            }
        }

        return 0;
    }
}