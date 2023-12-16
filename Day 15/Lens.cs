namespace Day_15;

public class Lens
{
    public string Label { get; private set; }
    private int _focalLength;
    public int FocalLength
    {
        get { return _focalLength; }
        set { _focalLength = value; }
    }

    public Lens(string label, int focalLength)
    {
        Label = label;
        _focalLength = focalLength;
    }
}