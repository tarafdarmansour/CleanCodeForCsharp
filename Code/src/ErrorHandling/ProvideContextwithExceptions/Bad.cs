namespace ProvideContextwithExceptions;

public class Bad
{
    public double Divide(double numerator, double denominator)
    {
        if (denominator == 0)
            throw new Exception("divide by zero");

        return numerator / denominator;
    }
}