namespace Day_13;

public class Pattern
{
    private readonly List<string> _patterns = new();
    private readonly int _width;
    private readonly int _height;

    public int NumAboveAfterRemovingSmudge { get; private set; }
    public int NumLeftAfterRemovingSmudge { get; private set; }

    public Pattern(List<string> patterns)
    {
        _patterns = new(patterns);
        _width = patterns[0].Length;
        _height = patterns.Count;
    }

    public int GetNumLeftOfReflection()
    {
        for (int i = 0; i < _width - 1; i++)
        {
            bool foundMirror = true;
            int currentNumLeft = 0;

            while (i - currentNumLeft >= 0 && i + 1 + currentNumLeft < _width)
            {
                bool allInNextColumnMatch = _patterns.All(p => p[i - currentNumLeft] == p[i + 1 + currentNumLeft]);

                if (!allInNextColumnMatch)
                {
                    foundMirror = false;
                    break;
                }

                currentNumLeft++;
            }

            if (foundMirror)
            {
                return i + 1;
            }
        }

        return 0;
    }

    public int GetNumAboveReflection()
    {
        for (int i = 0; i < _height - 1; i++)
        {
            bool foundMirror = true;
            int currentNumAbove = 0;

            while (i - currentNumAbove >= 0 && i + 1 + currentNumAbove < _height)
            {
                bool allInNextRowMatch = _patterns[i - currentNumAbove] == _patterns[i + 1 + currentNumAbove];

                if (!allInNextRowMatch)
                {
                    foundMirror = false;
                    break;
                }

                currentNumAbove++;
            }

            if (foundMirror)
            {
                return i + 1;
            }
        }

        return 0;
    }

    public void FixSmudge()
    {
        for (int startRowIndex = 0; startRowIndex < _height; startRowIndex++)
        {
            for (int currentRowIndex = startRowIndex + 1; currentRowIndex < _height; currentRowIndex += 2)
            {
                int numDiff = 0;
                int index = 0;

                for (int k = 0; k < _width; k++)
                {
                    if (_patterns[startRowIndex][k] != _patterns[currentRowIndex][k])
                    {
                        numDiff++;
                        index = k;
                    }
                }

                if (numDiff == 1)
                {
                    char current = _patterns[startRowIndex][index];
                    char opposite = current == '.' ? '#' : '.';

                    string currentRow = _patterns[startRowIndex];
                    string newRow = _patterns[startRowIndex][..index] + opposite + _patterns[startRowIndex][(index + 1)..];

                    _patterns[startRowIndex] = newRow;

                    if (IsHorizontalReflection((startRowIndex + currentRowIndex) / 2))
                    {
                        NumAboveAfterRemovingSmudge = (startRowIndex + currentRowIndex) / 2 + 1;
                        return;
                    }

                    _patterns[startRowIndex] = currentRow;
                }
            }
        }

        for (int column = 0; column < _width; column++)
        {
            for (int currentColumn = column + 1; currentColumn < _width; currentColumn += 2)
            {
                int numDiff = 0;
                int index = 0;

                for (int k = 0; k < _height; k++)
                {
                    if (_patterns[k][column] != _patterns[k][currentColumn])
                    {
                        numDiff++;
                        index = k;
                    }
                }

                if (numDiff == 1)
                {
                    char current = _patterns[index][column];
                    char opposite = current == '.' ? '#' : '.';

                    string currentRow = _patterns[index];
                    string newRow = _patterns[index][..column] + opposite + _patterns[index][(column + 1)..];

                    _patterns[index] = newRow;

                    if (IsVerticalReflection((column + currentColumn) / 2))
                    {
                        NumLeftAfterRemovingSmudge = (column + currentColumn) / 2 + 1;
                        return;
                    }

                    _patterns[index] = currentRow;
                }
            }
        }
    }

    private bool IsHorizontalReflection(int startRow)
    {
        int currentNumAbove = 0;

        while (startRow - currentNumAbove >= 0 && startRow + 1 + currentNumAbove < _height)
        {
            bool allInNextRowMatch = _patterns[startRow - currentNumAbove] == _patterns[startRow + 1 + currentNumAbove];

            if (!allInNextRowMatch)
            {
                return false;
            }

            currentNumAbove++;
        }

        return true;
    }

    private bool IsVerticalReflection(int startColumn)
    {
        int currentNumLeft = 0;

        while (startColumn - currentNumLeft >= 0 && startColumn + 1 + currentNumLeft < _width)
        {
            bool allInNextColumnMatch = _patterns.All(p => p[startColumn - currentNumLeft] == p[startColumn + 1 + currentNumLeft]);

            if (!allInNextColumnMatch)
            {
                return false;
            }

            currentNumLeft++;
        }

        return true;
    }
}