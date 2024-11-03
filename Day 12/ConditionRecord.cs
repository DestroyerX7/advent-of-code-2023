using System.Text.RegularExpressions;

namespace Day_12;

public class ConditionRecord
{
    private string _springConditions;

    private readonly List<int> _groups = new();

    public ConditionRecord(string conditionRecord)
    {
        string[] split = conditionRecord.Split(' ');
        _springConditions = split[0];
        _groups = split[1].Split(',').Select(int.Parse).ToList();
    }

    public int GetNumPossabilities()
    {
        return GetNumPossabilities(0, 0, _springConditions);
    }

    private int GetNumPossabilities(int startIndex, int numIndex, string springConditions)
    {
        int numPossabilities = 0;
        int currentIndex = startIndex;
        int numInARow = _groups[numIndex];
        string currentSpringConditions = springConditions;

        while (currentIndex + numInARow - 1 < _springConditions.Length)
        {
            bool isSpace = _springConditions[currentIndex..(currentIndex + numInARow)].All(c => c == '?' || c == '#');

            // Idk but I think this makes it faster
            if (isSpace && currentIndex + numInARow < _springConditions.Length && _springConditions[currentIndex + numInARow] == '#')
            {
                currentIndex++;
                continue;
            }

            if (numIndex == _groups.Count - 1 && isSpace)
            {
                string connected = new('#', numInARow);
                string newSpringConditions = currentSpringConditions[..currentIndex] + connected + currentSpringConditions[(currentIndex + numInARow)..];
                numPossabilities += GetGroupNums(newSpringConditions).SequenceEqual(_groups) ? 1 : 0;
            }
            else if (isSpace)
            {
                string connected = new('#', numInARow);
                string newSpringConditions = currentSpringConditions[..currentIndex] + connected + currentSpringConditions[(currentIndex + numInARow)..];
                numPossabilities += GetNumPossabilities(currentIndex + numInARow + 1, numIndex + 1, newSpringConditions);
            }

            // Idk but I think this makes it faster
            if (_springConditions[currentIndex] == '#')
            {
                break;
            }

            currentIndex++;
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

        if (numConnected != 0)
        {
            groups.Add(numConnected);
            numConnected = 0;
        }

        return groups;
    }

    public void Unfold()
    {
        string originalSpringConditions = _springConditions;
        List<int> originalGroups = new(_groups);

        for (int i = 0; i < 4; i++)
        {
            _springConditions += "?" + originalSpringConditions;

            foreach (int group in originalGroups)
            {
                _groups.Add(group);
            }
        }
    }
}