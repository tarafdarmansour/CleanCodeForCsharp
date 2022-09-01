namespace MethodNames.Good;

public class Complex
{
    private double doublePartOfComplex;

    private Complex(double doublePartOfComplex)
    {
        this.doublePartOfComplex = doublePartOfComplex;
    }

    public static Complex FromDoubleNumber(double d)
    {
        return new Complex(d);
    }
}

public class Employee
{
    private string name;

    public string GetName()
    {
        return name;
    }
}

public class Customer
{
    private string name;

    public void SetName(string s)
    {
        name = s;
    }
}

public class PayCheck
{
    private PayCheckState state;

    public bool IsPosted()
    {
        return state == PayCheckState.Posted;
    }

    private enum PayCheckState
    {
        Calcelated,
        Posted
    }
}

public class Main
{
    public void ShowSampleCase()
    {
        var complex = Complex.FromDoubleNumber(23.0);
        var employee = new Employee();
        var employeeName = employee.GetName();
        var customer = new Customer();
        customer.SetName("Mike");
        var payCheck = new PayCheck();
        if (payCheck.IsPosted())
        {
            //do somethings
        }
    }
}