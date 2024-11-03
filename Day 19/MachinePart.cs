namespace Day_19;

public class MachinePart
{
    public int XVal { get; private set; }
    public int MVal { get; private set; }
    public int AVal { get; private set; }
    public int SVal { get; private set; }
    public int TotalVal => XVal + MVal + AVal + SVal;

    public MachinePart(int xVal, int mVal, int aVal, int sVal)
    {
        XVal = xVal;
        MVal = mVal;
        AVal = aVal;
        SVal = sVal;
    }
}