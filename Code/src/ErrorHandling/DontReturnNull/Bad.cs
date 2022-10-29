namespace DontReturnNull;

public class Bad
{
    private decimal totalPay;

    public void run()
    {
        var employees = getEmployees();
        if (employees != null)
            foreach (var e in employees)
                totalPay += e.getPay();
    }

    private List<Employee> getEmployees()
    {
        if (DateTime.Now.Second % 2 == 0)
            return new List<Employee>
            {
                new(),
                new()
            };
        return null;
    }
}