namespace Day_11;

public class UniverseNode
{
    public double GCost { get; private set; } = double.MaxValue;
    public double HCost { get; private set; }
    public double FCost => GCost + HCost;

    public long XPos { get; private set; }
    public long YPos { get; private set; }

    private readonly List<UniverseNode> _connections = new();

    private UniverseNode? _previousNode;

    public UniverseNode(long xPos, long ypos)
    {
        XPos = xPos;
        YPos = ypos;
    }

    public void AddConnection(UniverseNode universeNode)
    {
        _connections.Add(universeNode);
    }

    public long GetShortestPath(UniverseNode targetNode)
    {
        return Math.Abs(targetNode.XPos - XPos) + Math.Abs(targetNode.YPos - YPos);
    }

    // For some reason I thought you had to use A* pathfinding at first and didn't think of a simpler way
    public long GetShortestPathWithAStar(UniverseNode targetNode)
    {
        GCost = 0;

        List<UniverseNode> lookedAt = new();
        List<UniverseNode> fullySearched = new();

        UniverseNode currentNode = this;

        do
        {
            foreach (UniverseNode universeNode in currentNode._connections.Except(lookedAt))
            {
                long xDistance = targetNode.XPos - universeNode.XPos;
                long yDistance = targetNode.YPos - universeNode.YPos;
                double distanceFromTarget = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
                universeNode.HCost = distanceFromTarget;

                double pathDistance = currentNode.GCost + 1;
                if (pathDistance < universeNode.GCost)
                {
                    universeNode.GCost = pathDistance;
                    universeNode._previousNode = currentNode;
                }

                lookedAt.Add(universeNode);
            }

            UniverseNode nextNode = lookedAt.Except(fullySearched).OrderBy(u => u.FCost).First();
            fullySearched.Add(currentNode);
            currentNode = nextNode;
        }
        while (lookedAt.Count > 0 && currentNode != targetNode);

        int shortestPathDistance = 0;

        while (currentNode._previousNode != null)
        {
            currentNode = currentNode._previousNode;
            shortestPathDistance++;
        }

        return shortestPathDistance;
    }

    public void Reset()
    {
        GCost = double.MaxValue;
        HCost = 0;
        _previousNode = null;
    }

    public override string ToString()
    {
        return $"Position : ({XPos}, {YPos})";
    }
}