namespace DoOneThing;

public class Good
{
    public void pay(List<Employee> employees)
    {
        foreach (var employee in employees) payIfNecessary(employee);
    }

    private void payIfNecessary(Employee e)
    {
        if (e.isPayDay())
            calculateAndDeliverPay(e);
    }

    private void calculateAndDeliverPay(Employee employee)
    {
        var pay = employee.calculatePay();
        employee.deliverPay(pay);
    }
}