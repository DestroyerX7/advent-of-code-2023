namespace Day_5;

public struct ConversionRange
{
    public long DestinationStart;
    public long SourceStart;
    public long Length;

    public ConversionRange(long destinationStart, long sourceStart, long length)
    {
        DestinationStart = destinationStart;
        SourceStart = sourceStart;
        Length = length;
    }

    public readonly (bool, long) ContainsNum(long sourceNum)
    {
        if (sourceNum >= SourceStart && sourceNum < SourceStart + Length)
        {
            return (true, DestinationStart - SourceStart + sourceNum);
        }

        return (false, -1);
    }

    public readonly (bool, long) ContainsDestinationNum(long destinationNum)
    {
        if (destinationNum >= DestinationStart && destinationNum < DestinationStart + Length)
        {
            return (true, SourceStart - DestinationStart + destinationNum);
        }

        return (false, -1);
    }
}

public class Conversion
{
    private readonly List<ConversionRange> _convertionRanges = new();

    public Conversion(List<ConversionRange> conversionRanges)
    {
        foreach (ConversionRange conversionRange in conversionRanges)
        {
            _convertionRanges.Add(conversionRange);
        }
    }

    public long GetDestinationNum(long sourceNum)
    {
        foreach (ConversionRange conversionRange in _convertionRanges)
        {
            (bool, long) containsNumInfo = conversionRange.ContainsNum(sourceNum);

            if (containsNumInfo.Item1)
            {
                return containsNumInfo.Item2;
            }
        }

        return sourceNum;
    }

    public static long IsPossible(long destinationNum, List<Conversion> conversions, int level)
    {
        if (level == 0)
        {
            return destinationNum;
        }

        Conversion currentConversion = conversions[level];

        long newDestinationNum = destinationNum;

        foreach (ConversionRange conversionRange in currentConversion._convertionRanges)
        {
            (bool, long) containsDestinationNumInfo = conversionRange.ContainsDestinationNum(destinationNum);

            if (containsDestinationNumInfo.Item1)
            {
                newDestinationNum = containsDestinationNumInfo.Item2;
                break;
            }
        }

        return IsPossible(newDestinationNum, conversions, level - 1);
    }
}