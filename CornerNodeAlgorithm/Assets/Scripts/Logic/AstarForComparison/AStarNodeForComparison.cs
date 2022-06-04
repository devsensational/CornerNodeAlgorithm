
public class AStarNodeForComparison
{
    private int x, y;
    private double hScore;
    private double fScore;
    private double gScore;
    private AStarNodeForComparison parentNode;

    public AStarNodeForComparison(int x, int y, double hScore, double gScore, AStarNodeForComparison parentNode)
    {
        this.x = x;
        this.y = y;
        this.hScore = hScore;
        this.gScore = gScore;
        this.parentNode = parentNode;
        fScore = hScore + gScore;
    }

    
    public int X => x;
    public int Y => y;
    public double HScore => hScore;
    public double FScore => fScore;
    public double GScore => gScore;
    public AStarNodeForComparison ParentNode => parentNode;
    
}
