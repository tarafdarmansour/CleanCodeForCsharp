using Newtonsoft.Json;

namespace ProvideContextwithExceptions;

public class Good
{
    public double Divide(double numerator, double denominator)
    {
        if (denominator == 0) ThrowInformativeException(numerator, denominator);

        return numerator / denominator;
    }

    private static void ThrowInformativeException(double numerator, double denominator)
    {
        throw new Exception(JsonConvert.SerializeObject(new
        {
            Message = "divide by zero",
            Method = "Divide",
            Class = "Good",
            numerator,
            denominator
        }));
    }
}