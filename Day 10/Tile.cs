namespace Day_10;

public class Tile
{
    public char TileType { get; private set; }

    private Tile? _up;
    public Tile Up
    {
        set { _up = value; }
    }

    private Tile? _down;
    public Tile Down
    {
        set { _down = value; }
    }

    private Tile? _left;
    public Tile Left
    {
        set { _left = value; }
    }

    private Tile? _right;
    public Tile Right
    {
        set { _right = value; }
    }

    private bool _loopTile;
    public bool LoopTile
    {
        get { return _loopTile; }
        set { _loopTile = value; }
    }

    public Tile(char tileType, Tile? up = null, Tile? down = null, Tile? left = null, Tile? right = null)
    {
        TileType = tileType;
        _up = up;
        _down = down;
        _left = left;
        _right = right;
    }

    public void SetConnections()
    {
        if (!CanConnectUp() || _up != null && !_up.CanConnectDown())
        {
            _up = null;
        }

        if (!CanConnectDown() || _down != null && !_down.CanConnectUp())
        {
            _down = null;
        }

        if (!CanConnectLeft() || _left != null && !_left.CanConnectRight())
        {
            _left = null;
        }

        if (!CanConnectRight() || _right != null && !_right.CanConnectLeft())
        {
            _right = null;
        }
    }

    private bool CanConnectUp()
    {
        return TileType == 'S' || TileType == '|' || TileType == 'L' || TileType == 'J';
    }

    private bool CanConnectDown()
    {
        return TileType == 'S' || TileType == '|' || TileType == 'F' || TileType == '7';
    }

    private bool CanConnectLeft()
    {
        return TileType == 'S' || TileType == '-' || TileType == '7' || TileType == 'J';
    }

    private bool CanConnectRight()
    {
        return TileType == 'S' || TileType == '-' || TileType == 'L' || TileType == 'F';
    }

    public Tile? NextInLoop(Tile? previous)
    {
        Tile? nextInLoop = null;

        if (_up != null && _up != previous)
        {
            nextInLoop = _up;
        }

        if (_down != null && _down != previous)
        {
            nextInLoop = _down;
        }

        if (_left != null && _left != previous)
        {
            nextInLoop = _left;
        }

        if (_right != null && _right != previous)
        {
            nextInLoop = _right;
        }

        return nextInLoop;
    }

    public void ConvertStartTile()
    {
        if (TileType != 'S')
        {
            return;
        }

        if (_up != null && _right != null)
        {
            TileType = 'L';
        }
        else if (_up != null && _left != null)
        {
            TileType = 'J';
        }
        else if (_up != null && _down != null)
        {
            TileType = '|';
        }
        else if (_down != null && _right != null)
        {
            TileType = 'F';
        }
        else if (_down != null && _left != null)
        {
            TileType = '7';
        }
        else if (_left != null && _right != null)
        {
            TileType = '-';
        }
    }

    public bool HasNorthFacingSide()
    {
        return TileType == '|' || TileType == 'J' || TileType == 'L';
    }

    public override string ToString()
    {
        return TileType.ToString();
    }
}