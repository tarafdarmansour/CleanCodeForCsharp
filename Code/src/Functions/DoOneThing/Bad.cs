namespace DoOneThing;

public class Bad
{
    public void pay(List<Employee> employees)
    {
        foreach (var employee in employees)
            if (employee.isPayDay())
            {
                var pay = employee.calculatePay();
                employee.deliverPay(pay);
            }
    }
}