
public class AStarNode
{
    private PathNode pNode;
    private double hScore;
    private double fScore;
    private double gScore;
    private AStarNode parentNode;

    public AStarNode(PathNode pNode, double hScore, double gScore, AStarNode parentNode)
    {
        this.pNode = pNode;
        this.hScore = hScore;
        this.gScore = gScore;
        fScore = hScore + gScore;
        this.parentNode = parentNode;
    }

    public PathNode GetNode
    {
        get { return pNode; }
    }

    public double HScore
    {
        get => hScore;
        set => hScore = value;
    }

    public double FScore
    {
        get => fScore;
        set => fScore = value;
    }

    public double GScore
    {
        get => gScore;
        set => gScore = value;
    }

    public AStarNode ParentNode
    {
        get => parentNode;
        set => parentNode = value;
    }
}
