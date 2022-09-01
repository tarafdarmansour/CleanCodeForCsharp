namespace MethodNames.Bad;

public class Complex
{
    private double doublePartOfComplex;

    public Complex(double d)
    {
        doublePartOfComplex = d;
    }
}

public class Employee
{
    private string name;

    public string NameGetter()
    {
        return name;
    }
}

public class Customer
{
    private string name;

    public void NameSettr(string s)
    {
        name = s;
    }
}

public class PayCheck
{
    private PayCheckState state;

    public int ReturnPayCheckState()
    {
        return (int)state;
    }

    private enum PayCheckState
    {
        Calcelated,
        Posted
    }
}