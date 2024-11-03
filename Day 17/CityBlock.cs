namespace Day_17;

public class CityBlock
{
    public int PathCost { get; private set; }
    public int HeatLossAmount { get; private set; }

    private readonly List<CityBlock> _connections = new();
    private readonly Dictionary<CityBlock, Direction> _connectionToDirection = new();

    public CityBlock(int heatLossAmount)
    {
        HeatLossAmount = heatLossAmount;
        PathCost = int.MaxValue;
    }

    public void AddConnection(CityBlock cityBlock, Direction direction)
    {
        if (_connectionToDirection.ContainsValue(direction))
        {
            throw new Exception("City block aready connects to that direction");
        }

        _connections.Add(cityBlock);
        _connectionToDirection.Add(cityBlock, direction);
    }

    public int FindLeastHeatLossToTarget(CityBlock target)
    {
        PathCost = 0;

        CityBlock currentCityBlock = this;
        List<CityBlock> lookedAt = new();
        List<CityBlock> fullySearched = new();

        do
        {
            foreach (CityBlock cityBlock in currentCityBlock._connections.Except(fullySearched))
            {
                // Direction directionFromCurrent = currentCityBlock._connectionToDirection[cityBlock];

                // if (directionFromCurrent == lastDirection && sameDirectionCount == 3)
                // {
                //     continue;
                // }

                int pathCost = currentCityBlock.PathCost + cityBlock.HeatLossAmount;
                if (pathCost < cityBlock.PathCost)
                {
                    cityBlock.PathCost = pathCost;
                }

                lookedAt.Add(cityBlock);
            }

            CityBlock nextCityBlock = lookedAt.Except(fullySearched).OrderBy(c => c.PathCost).First();
            fullySearched.Add(currentCityBlock);
            currentCityBlock = nextCityBlock;
        }
        while (currentCityBlock != target && lookedAt.Count > fullySearched.Count);

        return 0;
    }
}

public enum Direction
{
    Top,
    Bottom,
    Left,
    Right,
    None,
}