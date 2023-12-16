namespace Day_15;

public class Box
{
    public int BoxNum { get; private set; }
    private readonly List<Lens> _lenses = new();

    public Box(int boxNum)
    {
        BoxNum = boxNum;
    }

    public void AddLens(Lens lens)
    {
        Lens? lensInList = _lenses.FirstOrDefault(l => l.Label == lens.Label);

        if (lensInList != null)
        {
            lensInList.FocalLength = lens.FocalLength;
        }
        else
        {
            _lenses.Add(lens);
        }
    }

    public void RemoveLens(string lensLabel)
    {
        Lens? lensToRemove = _lenses.FirstOrDefault(l => l.Label == lensLabel);

        if (lensToRemove != null)
        {
            _lenses.Remove(lensToRemove);
        }
    }

    public int GetSumFocusingPower()
    {
        int sum = 0;

        for (int i = 0; i < _lenses.Count; i++)
        {
            int focusingPower = (1 + BoxNum) * (i + 1) * _lenses[i].FocalLength;
            sum += focusingPower;
        }

        return sum;
    }
}