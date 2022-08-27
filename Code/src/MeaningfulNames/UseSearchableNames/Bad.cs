namespace UseSearchableNames;

public class Bad
{
    public double FooFuction(int[] t)
    {
        double s = 0;
        for (var j = 0; j < 34; j++) s += t[j] * 4 / 5;

        return s;
    }
}