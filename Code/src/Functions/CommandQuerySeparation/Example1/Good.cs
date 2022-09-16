namespace CommandQuerySeparation.Example1;

public class Good
{
    private int _x;

    public void Increment()
    {
        _x++;
    }

    public int GetValue()
    {
        return _x;
    }
}