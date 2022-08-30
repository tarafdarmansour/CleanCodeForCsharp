namespace AvoidMentalMapping;

public class Good
{
    public int CalculateProductSomeData(List<Product> products)
    {
        var result = 0;
        foreach (var product in products)
        {
            // lots of code here

            var evaluatedFooProperty = product.FooProperty;

            result += evaluatedFooProperty;

            // lots of code here
        }

        return result;
    }
}