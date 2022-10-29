namespace DontReturnNull;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public decimal getPay()
    {
        return (decimal)new Random().NextDouble();
    }
}