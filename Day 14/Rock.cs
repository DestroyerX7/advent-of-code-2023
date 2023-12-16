namespace Day_14;

public class Rock
{
    public char RockType { get; private set; }
    public int XPos { get; private set; }
    public int YPos { get; private set; }

    public Rock(char rockType, int xPos, int yPos)
    {
        RockType = rockType;
        XPos = xPos;
        YPos = yPos;
    }

    public void RollNorth()
    {
        YPos--;
    }

    public void RollEast()
    {
        XPos++;
    }

    public void RollSouth()
    {
        YPos++;
    }

    public void RollWest()
    {
        XPos--;
    }

    public override string ToString()
    {
        return RockType.ToString();
    }
}