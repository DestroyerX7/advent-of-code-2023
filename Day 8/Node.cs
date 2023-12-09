namespace Day_8;

public class Node
{
    public string Position { get; private set; }
    public string Right { get; private set; }
    public string Left { get; private set; }

    public Node(string pos, string left, string right)
    {
        Position = pos;
        Left = left;
        Right = right;
    }

    public string GetDirection(char leftOrRight)
    {
        return leftOrRight == 'L' ? Left : Right;
    }

    public override string ToString()
    {
        return $"{Position} = ({Left}, {Right})";
    }
}