namespace CommandQuerySeparation.Example1;

public class Bad
{
    private readonly object _lock = new();
    private int _x;

    public int IncrementAndGetValue()
    {
        lock (_lock)
        {
            _x++;
            return _x;
        }
    }
}