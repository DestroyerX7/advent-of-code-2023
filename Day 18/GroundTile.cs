namespace Day_18;

public class GroundTile
{
    public static readonly List<GroundTile> GroundTiles = new();
    public static readonly Dictionary<Position, GroundTile> PositionToGroundTile = new();

    public long XPos { get; private set; }
    public long YPos { get; private set; }

    private GroundTile? _topGroundTile;
    private GroundTile? _bottomGroundTile;
    private GroundTile? _leftGroundTile;
    public GroundTile? LeftGroundTile { get { return _leftGroundTile; } }

    private GroundTile? _rightGroundTile;

    public GroundTile(long xPos, long yPos)
    {
        XPos = xPos;
        YPos = yPos;

        Position pos = new(XPos, YPos);

        if (PositionToGroundTile.ContainsKey(pos))
        {
            return;
        }

        GroundTiles.Add(this);
        PositionToGroundTile.Add(pos, this);
    }

    public GroundTile DigInDirection(char direction, long numTimes)
    {
        if (direction == 'U')
        {
            GroundTile groundTile = new(XPos, YPos + numTimes);
            _topGroundTile = groundTile;
            groundTile._bottomGroundTile = this;
            return groundTile;
        }
        else if (direction == 'D')
        {
            GroundTile groundTile = new(XPos, YPos - numTimes);
            _bottomGroundTile = groundTile;
            groundTile._topGroundTile = this;
            return groundTile;
        }
        else if (direction == 'L')
        {
            GroundTile groundTile = new(XPos - numTimes, YPos);
            _leftGroundTile = groundTile;
            groundTile._rightGroundTile = this;
            return groundTile;
        }
        else if (direction == 'R')
        {
            GroundTile groundTile = new(XPos + numTimes, YPos);
            _rightGroundTile = groundTile;
            groundTile._leftGroundTile = this;
            return groundTile;
        }
        else
        {
            throw new Exception($"Direction \"{direction}\" does not exist");
        }
    }

    public bool HasWestFaceingWall()
    {
        return _topGroundTile != null;
    }

    public static long MinXPos()
    {
        GroundTile? minXPosGroundTile = GroundTiles.MinBy(g => g.XPos);

        if (minXPosGroundTile != null)
        {
            return minXPosGroundTile.XPos;
        }

        throw new Exception("Something went wrong");
    }

    public static long MaxXPos()
    {
        GroundTile? maxXPosGroundTile = GroundTiles.MaxBy(g => g.XPos);

        if (maxXPosGroundTile != null)
        {
            return maxXPosGroundTile.XPos;
        }

        throw new Exception("Something went wrong");
    }

    public static long MinYPos()
    {
        GroundTile? minYPosGroundTile = GroundTiles.MinBy(g => g.YPos);

        if (minYPosGroundTile != null)
        {
            return minYPosGroundTile.YPos;
        }

        throw new Exception("Something went wrong");
    }

    public static long MaxYPos()
    {
        GroundTile? maxYPosGroundTile = GroundTiles.MaxBy(g => g.YPos);

        if (maxYPosGroundTile != null)
        {
            return maxYPosGroundTile.YPos;
        }

        throw new Exception("Something went wrong");
    }
}

public struct Position : IEquatable<Position>
{
    public long XPos;
    public long YPos;

    public Position(long xPos, long yPos)
    {
        XPos = xPos;
        YPos = yPos;
    }

    public readonly bool Equals(Position other)
    {
        return XPos == other.XPos && YPos == other.YPos;
    }
}
