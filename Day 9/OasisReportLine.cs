namespace Day_9;

public class OasisReportLine
{
    private readonly List<string> _lines = new();

    public OasisReportLine(string line)
    {
        _lines.Add(line);

        while (true)
        {
            string[] split = _lines.Last().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string newLine = "";
            bool allZeros = true;

            for (int i = 1; i < split.Length; i++)
            {
                int lastVal = int.Parse(split[i - 1]);
                int currentVal = int.Parse(split[i]);
                int difference = currentVal - lastVal;
                newLine += difference + " ";

                if (difference != 0)
                {
                    allZeros = false;
                }
            }

            _lines.Add(newLine);

            if (allZeros)
            {
                break;
            }
        }
    }

    public int ExtrapolateRight()
    {
        int previousVal = 0;

        for (int i = _lines.Count - 1; i >= 0; i--)
        {
            int lastvalInLine = int.Parse(_lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
            int added = previousVal + lastvalInLine;
            _lines[i] = _lines[i].Trim() + " " + added;
            previousVal = added;
        }

        return previousVal;
    }

    public int ExtrapolateLeft()
    {
        int previousVal = 0;

        for (int i = _lines.Count - 1; i >= 0; i--)
        {
            int firstvalInLine = int.Parse(_lines[i][.._lines[i].IndexOf(" ")]);
            int substracted = firstvalInLine - previousVal;
            _lines[i] = substracted + " " + _lines[i].Trim();
            previousVal = substracted;
        }

        return previousVal;
    }

    public override string ToString()
    {
        string text = "";

        foreach (string line in _lines)
        {
            text += line + "\n";
        }

        return text;
    }
}