namespace Day_12;

public class ConditionRecord
{
    private string _springConditions;

    List<int> _groups = new();

    public ConditionRecord(string conditionRecord)
    {
        string[] split = conditionRecord.Split(' ');
        _springConditions = split[0];
        _groups = split[1].Split(',').Select(int.Parse).ToList();
    }

    // Doesnt work as a concept
    public int GetNumPossabilities()
    {
        int numPossabilities = 0;

        int firstQuestionMarkIndex = _springConditions.IndexOf("?");
        int lastQuestionMarkIndex = _springConditions.LastIndexOf("?");

        for (int i = firstQuestionMarkIndex; i <= lastQuestionMarkIndex; i++)
        {
            if (_springConditions[i] != '?')
            {
                continue;
            }

            string replacedFirstQuestionMark = _springConditions[..i] + "#" + _springConditions[(i + 1)..];

            for (int j = i + 1; j <= lastQuestionMarkIndex; j++)
            {
                if (j == i)
                {
                    continue;
                }

                string currentString = replacedFirstQuestionMark;

                for (var k = j; k <= lastQuestionMarkIndex; k++)
                {
                    if (currentString[k] == '?')
                    {
                        currentString = currentString[..k] + "#" + currentString[(k + 1)..];
                    }

                    numPossabilities += GetGroupNums(currentString).SequenceEqual(_groups) ? 1 : 0;
                }
            }
        }

        return numPossabilities;
    }

    private static List<int> GetGroupNums(string record)
    {
        List<int> groups = new();
        int numConnected = 0;

        foreach (char springCondition in record)
        {
            if (springCondition == '#')
            {
                numConnected++;
            }
            else if (numConnected != 0)
            {
                groups.Add(numConnected);
                numConnected = 0;
            }
        }

        return groups;
    }
}