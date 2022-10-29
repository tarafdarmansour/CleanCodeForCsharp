namespace DontReturnNull;

public class Good
{
    private decimal totalPay;

    public void run()
    {
        totalPay = getEmployees().Sum(e => e.getPay());
    }

    private List<Employee> getEmployees()
    {
        if (DateTime.Now.Second % 2 == 0)
            return new List<Employee>
            {
                new(),
                new()
            };
        return new List<Employee>();
    }
}