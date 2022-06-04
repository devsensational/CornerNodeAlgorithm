

public class Cell
{
    private int type = 2; 
    private int stat = 0;

    public Cell(int type)
    {
        this.type = type;
    }

    public int Type
    {
        get { return type; }
        set { type = value; }
    }
    public int Stat
    {
        get { return stat; }
        set { stat = value; }
    }
}
