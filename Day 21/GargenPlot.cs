namespace Day_21;

public class GardenPlot
{
    public int XPos { get; private set; }
    public int YPos { get; private set; }
    public bool CanBeReached { get; private set; }
    // public bool Checked { get; private set; }

    private readonly List<GardenPlot> _connections = new();

    public GardenPlot(int xPos, int yPos)
    {
        XPos = xPos;
        YPos = yPos;
    }

    public void AddConnection(GardenPlot gardenPlot)
    {
        _connections.Add(gardenPlot);
    }

    public void GetNum(int stepNum = 0)
    {
        // Checked = true;

        if (stepNum != 0 && stepNum % 2 == 0)
        {
            // System.Console.WriteLine(XPos + " " + YPos + " " + stepNum);
            CanBeReached = true;
        }

        if (stepNum == 64)
        {
            return;
        }

        foreach (GardenPlot gardenPlot in _connections)
        {
            // if (gardenPlot.Checked)
            // {
            //     continue;
            // }

            gardenPlot.GetNum(stepNum + 1);
        }
    }
}