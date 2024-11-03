namespace Day_22;

public class Brick
{
    private static readonly List<Brick> _bricks = new();

    public Position PositionOne { get; private set; }
    public Position PositionTwo { get; private set; }

    public Brick(Position positionOne, Position positionTwo)
    {
        PositionOne = positionOne;
        PositionTwo = positionTwo;
        _bricks.Add(this);
    }

    public void DoSomething()
    {
        int lowestCanFall = 0;
        List<int> ints = new();

        for (int x = PositionOne.X; x <= PositionTwo.X; x++)
        {
            for (int y = PositionOne.Y; y <= PositionTwo.Y; y++)
            {
                int currentZ = GetLowest();

                // while (currentZ >= 1 && ) 
            }
        }
    }

    private int GetLowest()
    {
        return Math.Min(PositionOne.Z, PositionTwo.Z);
    }
}

public struct Position : IEquatable<Position>
{
    public int X;
    public int Y;
    public int Z;

    public Position(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public readonly bool Equals(Position other)
    {
        return X == other.X && Y == other.Y && Z == other.Z;
    }
}