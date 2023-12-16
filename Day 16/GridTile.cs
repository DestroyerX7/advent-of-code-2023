namespace Day_16;

public class GridTile
{
    private enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }

    public bool Energized { get; private set; }
    public char TileType { get; private set; }

    private GridTile? _topTile;
    public GridTile TopTile
    {
        set { _topTile = value; }
    }

    private GridTile? _bottomTile;
    public GridTile BottomTile
    {
        set { _bottomTile = value; }
    }

    private GridTile? _leftTile;
    public GridTile LeftTile
    {
        set { _leftTile = value; }
    }

    private GridTile? _rightTile;
    public GridTile RightTile
    {
        set { _rightTile = value; }
    }

    private readonly List<Direction> _enteredFromDirections = new();

    public GridTile(char tileType, GridTile? topTile, GridTile? bottomTile, GridTile? leftTile, GridTile? righttile)
    {
        TileType = tileType;
        _topTile = topTile;
        _bottomTile = bottomTile;
        _leftTile = leftTile;
        _rightTile = righttile;
    }

    public void EnterFromLeft()
    {
        if (TileType != '.' && _enteredFromDirections.Contains(Direction.Left))
        {
            return;
        }

        _enteredFromDirections.Add(Direction.Left);
        Energized = true;

        switch (TileType)
        {
            case '.':
            case '-':
                _rightTile?.EnterFromLeft();
                break;
            case '/':
                _topTile?.EnterFromBottom();
                break;
            case '\\':
                _bottomTile?.EnterFromTop();
                break;
            case '|':
                _topTile?.EnterFromBottom();
                _bottomTile?.EnterFromTop();
                break;
        }
    }

    public void EnterFromRight()
    {
        if (TileType != '.' && _enteredFromDirections.Contains(Direction.Right))
        {
            return;
        }

        _enteredFromDirections.Add(Direction.Right);
        Energized = true;

        switch (TileType)
        {
            case '.':
            case '-':
                _leftTile?.EnterFromRight();
                break;
            case '/':
                _bottomTile?.EnterFromTop();
                break;
            case '\\':
                _topTile?.EnterFromBottom();
                break;
            case '|':
                _topTile?.EnterFromBottom();
                _bottomTile?.EnterFromTop();
                break;
        }
    }

    public void EnterFromTop()
    {
        if (TileType != '.' && _enteredFromDirections.Contains(Direction.Up))
        {
            return;
        }

        _enteredFromDirections.Add(Direction.Up);
        Energized = true;

        switch (TileType)
        {
            case '.':
            case '|':
                _bottomTile?.EnterFromTop();
                break;
            case '/':
                _leftTile?.EnterFromRight();
                break;
            case '\\':
                _rightTile?.EnterFromLeft();
                break;
            case '-':
                _leftTile?.EnterFromRight();
                _rightTile?.EnterFromLeft();
                break;
        }
    }

    public void EnterFromBottom()
    {
        if (TileType != '.' && _enteredFromDirections.Contains(Direction.Down))
        {
            return;
        }

        _enteredFromDirections.Add(Direction.Down);
        Energized = true;

        switch (TileType)
        {
            case '.':
            case '|':
                _topTile?.EnterFromBottom();
                break;
            case '/':
                _rightTile?.EnterFromLeft();
                break;
            case '\\':
                _leftTile?.EnterFromRight();
                break;
            case '-':
                _leftTile?.EnterFromRight();
                _rightTile?.EnterFromLeft();
                break;
        }
    }

    public void Rest()
    {
        _enteredFromDirections.Clear();
        Energized = false;
    }

    public override string ToString()
    {
        return Energized ? "#" : TileType.ToString();
    }
}