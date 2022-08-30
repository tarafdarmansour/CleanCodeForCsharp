namespace AvoidMentalMapping;

public class Product
{
    public int Id { get; set; }
    public int FooProperty { get; set; }
}

public class Bad
{
    public int CalculateProductSomeData(List<Product> products)
    {
        var result = 0;
        foreach (var p in products)
        {
            // lots of code here

            var evaluatedFooProperty = p.FooProperty;

            result += evaluatedFooProperty;

            // lots of code here
        }

        return result;
    }
}